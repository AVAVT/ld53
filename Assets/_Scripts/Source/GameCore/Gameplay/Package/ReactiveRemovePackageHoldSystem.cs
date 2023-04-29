using System.Collections.Generic;
using Entitas;

public class ReactiveRemovePackageHoldSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  public ReactiveRemovePackageHoldSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Package, GameMatcher.Destroyed));
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.hasPackage && entity.isDestroyed;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var e in entities) {
      _contexts.game.GetEntityWithDroneHoldingPackageId(e.entityId.Value)?.Destroy();
    }
  }
}