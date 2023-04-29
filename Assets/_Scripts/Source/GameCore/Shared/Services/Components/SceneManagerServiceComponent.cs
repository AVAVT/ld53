using Entitas;
using Entitas.CodeGeneration.Attributes;

[Service, Unique]
public class SceneManagerServiceComponent : IComponent
{
  public ISceneManagerService Instance;
}