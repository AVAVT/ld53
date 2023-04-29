using Entitas;
using Entitas.CodeGeneration.Attributes;

[Service, Unique]
public class GameManagerServiceComponent : IComponent
{
  public IGameManagerService Instance;
}