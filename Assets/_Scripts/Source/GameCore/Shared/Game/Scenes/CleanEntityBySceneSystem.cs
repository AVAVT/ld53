using System.Collections.Generic;
using Entitas;

public class CleanEntityBySceneSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  readonly IGroup<GameEntity> _sceneSpecificEntities;
  readonly List<GameEntity> _entityBuffer = new List<GameEntity>();

  public CleanEntityBySceneSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;

    _sceneSpecificEntities = contexts.game.GetGroup(GameMatcher.ExistInScene);
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.ActiveScene);
  }

  protected override bool Filter(GameEntity entity)
  {
    return true;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    var activeScene = _contexts.game.activeScene.Value;

    foreach (var entity in _sceneSpecificEntities.GetEntities(_entityBuffer))
    {
      if ((entity.existInScene.Value & activeScene) == 0) entity.Destroy();
    }
  }
}