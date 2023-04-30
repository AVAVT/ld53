using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class ReactiveSpawnPackageSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  readonly int _deliveryInterval;
  readonly List<Vector2Int> _spawnLocations;

  public ReactiveSpawnPackageSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
    _deliveryInterval = contexts.config.gameplayConfig.Value.DeliveryInterval;
    _spawnLocations = contexts.config.gameplayConfig.Value.IncomingZone;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.Turn);
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.turn.PackageTurn % _deliveryInterval == 0;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    if (!_contexts.game.hasIncomingCar) return;
    var car = _contexts.game.incomingCar;
    for (var i = 0; i < car.Packages.Count; i++) {
      var package = _contexts.game.CreateEntity();
      package.AddPackage(car.Packages[i]);
      package.AddExistInScene(SceneTag.Gameplay);
      package.AddMapPosition(_spawnLocations[i]);
    }

    _contexts.game.RemoveIncomingCar();
  }
}