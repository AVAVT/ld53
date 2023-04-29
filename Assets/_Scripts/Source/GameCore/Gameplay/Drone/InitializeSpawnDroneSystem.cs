using System.Collections.Generic;
using Entitas;

public class InitializeSpawnDroneSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
  readonly Contexts _contexts;
  public InitializeSpawnDroneSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
  }

  public void Initialize()
  {
    var drone1 = _contexts.game.CreateEntity();
    drone1.isDrone = true;
    drone1.AddMapPosition(new(0, 0));
    drone1.AddDroneAction(DroneAction.Fly);

    var drone2 = _contexts.game.CreateEntity();
    drone2.isDrone = true;
    drone2.AddMapPosition(new(4, 3));
    drone2.AddDroneAction(DroneAction.Fly);
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.Turn);
  }

  protected override bool Filter(GameEntity entity)
  {
    return true;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    // if (_contexts.game.turn.Value > 0) {
    //   _contexts.service.aIService.Instance.Captcha("10001");
    // }
  }
}