using Entitas;

public class TimeKeeperSystem : IInitializeSystem, IExecuteSystem
{
  readonly GameContext _gameContext;
  readonly ServiceContext _serviceContext;

  public TimeKeeperSystem(Contexts contexts)
  {
    _gameContext = contexts.game;
    _serviceContext = contexts.service;
  }

  public void Initialize()
  {
    if (!_gameContext.hasTime) _gameContext.SetTime(0, 0);
  }

  public void Execute()
  {
    if (_gameContext.isPause)
    {
      _gameContext.ReplaceTime(0, _gameContext.time.timeSinceLevelLoad);
    }
    else
    {
      _gameContext.ReplaceTime(
        _serviceContext.timeService.Instance.DeltaTime,
        _gameContext.time.timeSinceLevelLoad + _serviceContext.timeService.Instance.DeltaTime
      );
    }
  }
}