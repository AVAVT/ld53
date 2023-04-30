using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Entitas;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DevDef.Services
{
  public class ViewService : MonoBehaviour, IViewService
  {
    [SerializeField] RectTransform _backgroundLayer;
    [SerializeField] RectTransform _foregroundLayer;
    [SerializeField] RectTransform _popupLayer;
    [SerializeField] RectTransform _overlayLayer;

    Contexts _contexts;
    ConfigContext _configContext;
    ILoggingService _loggingService;

    public void Initialize(Contexts contexts)
    {
      _contexts = contexts;
      _configContext = contexts.config;
      _loggingService = contexts.service.loggingService.Instance;
    }

    // TODO pool these things
    public void AddViewForEntityIfNeeded(IEntity entity, int index, IComponent component)
    {
      var config = _configContext.GetEntityWithEntityPrefabLinkConfig(index)?.entityPrefabLinkConfig.Config;
      if (config == null) return;

      switch (config.Type) {
        case EntityViewType.UIView:
          LoadUIAsset(entity as GameEntity, config.PrefabReference);
          break;
        case EntityViewType.GameView:
        default:
          LoadGameAsset(entity as GameEntity, config.PrefabReference);
          break;
      }

      entity.OnComponentAdded -= AddViewForEntityIfNeeded;
    }

    public async void LoadGameAsset(GameEntity entity, AssetReference prefabReference)
    {
      try {
        var entityId = entity.entityId.Value;

        var prefab = (await LoadPrefab(prefabReference)).GetComponent<GameBaseController>();
        await UniTask.WaitForEndOfFrame(this);

        if (!entity.hasEntityId || entity.entityId.Value != entityId) return;

        var view = Instantiate(prefab);

        view.InitializeView(_contexts, entity);

        if (view is IEventListener eventListener) eventListener.RegisterListeners(_contexts, entity);

        entity.AddView(view);
      }
      catch (Exception e) {
        _loggingService.Error(e);
      }
    }

    public async void LoadUIAsset(GameEntity entity, AssetReference prefabReference)
    {
      try {
        var entityId = entity.entityId.Value;

        var prefab = (await LoadPrefab(prefabReference)).GetComponent<GameUIViewController>();
        await UniTask.WaitForEndOfFrame(this);

        if (!entity.hasEntityId || entity.entityId.Value != entityId) return;

        var layer = prefab.Layer;

        var view = Instantiate(prefab, LayerTransformFromTag(layer));
        view.InitializeView(_contexts, entity);

        if (view is IEventListener eventListener) eventListener.RegisterListeners(_contexts, entity);

        entity.AddView(view);
      }
      catch (Exception e) {
        _loggingService.Error(e);
      }
    }

    RectTransform LayerTransformFromTag(UILayer layer) => layer switch
    {
      UILayer.Background => _backgroundLayer,
      UILayer.Foreground => _foregroundLayer,
      UILayer.Popup => _popupLayer,
      UILayer.Overlay => _overlayLayer,
      _ => _foregroundLayer
    };

    public async Task<GameObject> LoadPrefab(AssetReference assetReference) => await Addressables.LoadAssetAsync<GameObject>(assetReference);
  }
}