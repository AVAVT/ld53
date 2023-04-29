using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "EntityPrefabLinkConfig", menuName = "Databases/EntityPrefabLinkConfig")]
public class EntityPrefabLinkConfig : ScriptableObject
{
  public KeyComponentName KeyComponentName;
  public AssetReference PrefabReference;
  public EntityViewType Type;
}