using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class ReactiveGameOverSuspicionSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  public ReactiveGameOverSuspicionSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.Suspicion);
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.hasSuspicion;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var e in entities) {
      if (e.suspicion.Value < 100) continue;
      _contexts.game.ReplaceLevelFinished(false);
    }
  }
}