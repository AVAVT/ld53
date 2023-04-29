using System.Collections.Generic;
using Entitas;

public class ResetTimeSinceLevelLoadSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  public ResetTimeSinceLevelLoadSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.ActiveScene);
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.hasActiveScene;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    var time = _contexts.game.timeEntity;
    _contexts.game.ReplaceTime(
      time.time.deltaTime,
      0
    );
  }
}