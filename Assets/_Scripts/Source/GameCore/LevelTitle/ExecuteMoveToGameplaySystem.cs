using Entitas;

public class ExecuteMoveToGameplaySystem : IExecuteSystem, IInitializeSystem
{
  readonly Contexts _contexts;
  bool _moved;
  float time = 0;
  public ExecuteMoveToGameplaySystem(Contexts contexts)
  {
    _contexts = contexts;
  }

  public void Initialize()
  {
    _moved = false;
  }

  public void Execute()
  {
    if (_moved) return;
    time += _contexts.game.time.deltaTime;
    if (time <= 1) return;

    _moved = true;
    _contexts.service.gameManagerService.Instance.ChangeScene(SceneTag.Gameplay);
  }
}