using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class ReactiveSpawnPackageSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  readonly int _deliveryInterval;
  readonly List<Vector2Int> _spawnLocations = new();

  public ReactiveSpawnPackageSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
    _deliveryInterval = contexts.config.gameplayConfig.Value.DeliveryInterval;
    var dropX = -(contexts.config.gameplayConfig.Value.BoardSize.x / 2) + 2;

    for (var y = -1; y < 2; y++) {
      for (var x = dropX - 1; x < dropX + 2; x++) {
        _spawnLocations.Add(new(x, y));
      }
    }
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
      package.AddMapPosition(_spawnLocations[i]);
    }
  }
}