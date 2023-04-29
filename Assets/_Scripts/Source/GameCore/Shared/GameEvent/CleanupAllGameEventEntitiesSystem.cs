using Entitas;

public class CleanupAllGameEventEntitiesSystem : ICleanupSystem
{
  readonly GameEventContext _gameEventContext;

  public CleanupAllGameEventEntitiesSystem(Contexts contexts)
  {
    _gameEventContext = contexts.gameEvent;
  }

  public void Cleanup()
  {
    foreach (var e in _gameEventContext.GetEntities())
      e.Destroy();
  }
}