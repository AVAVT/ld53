using System.Collections.Generic;
using Entitas;

public class ReactiveCreatePackageExplosion : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  public ReactiveCreatePackageExplosion(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(
      GameMatcher.AllOf(GameMatcher.Package, GameMatcher.Position, GameMatcher.Destroyed)
    );
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.hasPosition && entity.isDestroyed && entity.hasPackage;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var e in entities) {
      var explosion = _contexts.game.CreateEntity();
      explosion.AddPosition(e.position.Value);
      explosion.AddExistInScene(SceneTag.Gameplay);
      explosion.isExplosion = true;
    }
  }
}