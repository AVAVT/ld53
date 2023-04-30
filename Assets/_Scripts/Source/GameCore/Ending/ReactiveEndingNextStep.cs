using System.Collections.Generic;
using Entitas;

public class ReactiveEndingNextStep : ReactiveSystem<GameEventEntity>
{
  readonly Contexts _contexts;
  public ReactiveEndingNextStep(Contexts contexts) : base(contexts.gameEvent)
  {
    _contexts = contexts;
  }

  protected override ICollector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
  {
    return context.CreateCollector(GameEventMatcher.EndingNextEvent);
  }

  protected override bool Filter(GameEventEntity entity)
  {
    return entity.hasEndingNextEvent;
  }

  protected override void Execute(List<GameEventEntity> entities)
  {
    foreach (var entity in entities) {
      if (entity.endingNextEvent.Step != _contexts.game.ending.Step) continue;

      _contexts.game.ReplaceEnding(_contexts.game.ending.Step + 1);
    }
  }
}