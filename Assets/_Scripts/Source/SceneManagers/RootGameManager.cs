using System;
using System.Collections;
using Entitas;
using Entitas.VisualDebugging.Unity;
using TKLibs;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DevDef.SceneManagers
{
  public sealed class RootGameManager : BaseSystemRunner, IGameManagerService
  {
    public GameplayConfigModel GameplayConfigModel;

    [SerializeField] EntityPrefabLinkConfig[] _entityPrefabLinkConfig;

    CameraMasker _cameraMasker;

    protected override void Setup()
    {
      _contexts = Contexts.sharedInstance;
      _cameraMasker = Camera.main!.GetComponent<CameraMasker>();

      SetupConfigsData(_contexts);
      GetComponent<ServiceFactory>().SetupServices(_contexts, this);

      _cameraMasker.AddScene(SceneNameFromTag(SceneTag.MainMenu));
    }

    protected override void OnDestroy()
    {
      base.OnDestroy();

      foreach (var observer in FindObjectsOfType<ContextObserverBehaviour>(true))
        try {
          observer.contextObserver?.Deactivate();

          Destroy(observer.gameObject);
        }
        catch (Exception e) {
          Debug.LogException(e, this);
        }

      _contexts = null;
    }

    protected override Systems CreateSystems() => new RootGameFeature(_contexts);

    void SetupConfigsData(Contexts contexts)
    {
      var configContext = contexts.config;

      configContext.SetGameplayConfig(GameplayConfigModel);

#if UNITY_EDITOR
      _entityPrefabLinkConfig = GetAllInstances<EntityPrefabLinkConfig>();
      foreach (var link in _entityPrefabLinkConfig) {
        if (Array.IndexOf(GameComponentsLookup.componentNames, link.KeyComponentName.ToString()) < 0)
          Debug.LogError(
            $"GameContext don't have any component named {link.KeyComponentName}! Check Prefabs config and update accordingly!"
          );
      }
#endif

      foreach (var link in _entityPrefabLinkConfig) {
        configContext
          .CreateEntity()
          .AddEntityPrefabLinkConfig(
            Array.IndexOf(GameComponentsLookup.componentNames, link.KeyComponentName.ToString()),
            link
          );
      }
    }

#if UNITY_EDITOR
    static T[] GetAllInstances<T>() where T : ScriptableObject
    {
      var guids = AssetDatabase.FindAssets(
        "t:" + typeof(T).Name
      );
      var a = new T[guids.Length];
      for (var i = 0; i < guids.Length; i++) {
        var path = AssetDatabase.GUIDToAssetPath(guids[i]);
        a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
      }

      return a;
    }
#endif

    public void ChangeScene(SceneTag sceneTag, float delay = 0)
    {
      StopSceneSystems();
      StartCoroutine(DelaySwitchScene(sceneTag, delay));
    }

    public void Quit()
    {
      StopAllGameSystems();
      StartCoroutine(DelayedQuit());
    }

    public void StopAllGameSystems()
    {
      StopSceneSystems();
      StopAllSystems();
    }

    IEnumerator DelaySwitchScene(SceneTag sceneTag, float time)
    {
      yield return new WaitForSeconds(time);
      _cameraMasker.MaskSwitchScene(SceneNameFromTag(sceneTag));
    }

    static string SceneNameFromTag(SceneTag sceneTag) => sceneTag switch
    {
      SceneTag.MainMenu => "MainMenu",
      SceneTag.Gameplay => "Gameplay",
      SceneTag.LevelTitle => "LevelTitle",
      SceneTag.Tutorial => "Tutorial",
      _ => ""
    };

    static IEnumerator DelayedQuit()
    {
      yield return null;

      // TODO Quit
    }

    static void StopSceneSystems()
    {
      _contexts.service.sceneManagerService.Instance.StopAllSystems();
    }
  }
}