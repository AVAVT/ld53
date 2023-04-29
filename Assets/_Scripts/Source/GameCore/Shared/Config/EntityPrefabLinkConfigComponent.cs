using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
public class EntityPrefabLinkConfigComponent : IComponent
{
  [PrimaryEntityIndex] public int KeyComponentIndex;
  public EntityPrefabLinkConfig Config;
}