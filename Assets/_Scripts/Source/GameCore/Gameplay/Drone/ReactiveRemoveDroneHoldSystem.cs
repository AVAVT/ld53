using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class ReactiveRemoveDroneHoldSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  public ReactiveRemoveDroneHoldSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Drone, GameMatcher.Destroyed));
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.isDrone && entity.isDestroyed;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var e in entities) {
      _contexts.game.GetEntityWithDroneHoldingDroneId(e.entityId.Value)?.Destroy();
    }
  }
}