using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ActiveSceneComponent : IComponent
{
  public SceneTag Value;
}
