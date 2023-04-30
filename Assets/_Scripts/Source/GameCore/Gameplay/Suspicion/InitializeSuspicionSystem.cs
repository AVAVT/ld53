using Entitas;

public class InitializeSuspicionSystem : IInitializeSystem
{
  readonly Contexts _contexts;
  public InitializeSuspicionSystem(Contexts contexts)
  {
    _contexts = contexts;
  }

  public void Initialize()
  {
    _contexts.game.SetSuspicion(0);
    _contexts.game.suspicionEntity.AddExistInScene(SceneTag.Gameplay);
  }
}