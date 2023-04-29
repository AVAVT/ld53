using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Entitas;

public interface IViewService
{
  void AddViewForEntityIfNeeded(IEntity entity, int index, IComponent component);
  void LoadGameAsset(GameEntity entity, AssetReference prefabReference);
  void LoadUIAsset(GameEntity entity, AssetReference prefabReference);
  Task<GameObject> LoadPrefab(AssetReference assetReference);
}