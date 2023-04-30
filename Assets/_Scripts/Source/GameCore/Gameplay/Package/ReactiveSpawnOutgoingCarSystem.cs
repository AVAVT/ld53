using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ReactiveSpawnOutgoingCarSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  readonly int _deliveryInterval;
  readonly List<Vector2Int> _outgoingZone;
  readonly int _firstDeliveryBuffer;
  public ReactiveSpawnOutgoingCarSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
    _deliveryInterval = contexts.config.gameplayConfig.Value.Levels[_contexts.game.level.Value].DeliveryInterval;
    _firstDeliveryBuffer = contexts.config.gameplayConfig.Value.Levels[_contexts.game.level.Value].FirstDeliveryBuffer;
    _outgoingZone = _contexts.config.gameplayConfig.Value.OutgoingZone;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.Turn);
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.turn.Value == 3 || (entity.turn.Value >= (_firstDeliveryBuffer + _deliveryInterval) && (entity.turn.Value - _firstDeliveryBuffer - 3) % _deliveryInterval == 0);
  }

  protected override void Execute(List<GameEntity> entities)
  {
    if (_contexts.game.hasLevelFinished) return;

    var numberToTake = _contexts.game.levelDeliveries.AmountPerDelivery;
    List<PackageType> packages = new();
    while (numberToTake > 0 && _contexts.game.levelDeliveries.Packages.Count > 0) {
      packages.Add(_contexts.game.levelDeliveries.Packages.RemoveRandom());
      numberToTake--;
    }

    for (var i = 0; i < packages.Count; i++) {
      var expect = _contexts.game.CreateEntity();
      expect.AddExpectedDelivery(packages[i]);
      expect.AddMapPosition(_outgoingZone[i]);
      expect.AddExistInScene(SceneTag.Gameplay);
    }

    var car = _contexts.game.CreateEntity();
    car.AddOutgoingCar(packages);
    car.AddExistInScene(SceneTag.Gameplay);
  }
}