using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ReactivePerformDeliverySystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  readonly int _deliveryInterval;
  readonly IGroup<GameEntity> _expectations;
  readonly List<GameEntity> _cache = new();
  readonly int _firstDeliveryBuffer;

  public ReactivePerformDeliverySystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
    _deliveryInterval = contexts.config.gameplayConfig.Value.Levels[_contexts.game.level.Value].DeliveryInterval;
    _firstDeliveryBuffer = contexts.config.gameplayConfig.Value.Levels[_contexts.game.level.Value].FirstDeliveryBuffer;
    _expectations = contexts.game.GetGroup(GameMatcher.ExpectedDelivery);
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.Turn);
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.turn.Value >= (_firstDeliveryBuffer + _deliveryInterval) && (entity.turn.Value - _firstDeliveryBuffer) % _deliveryInterval == 0;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    if (_contexts.game.hasLevelFinished) return;

    foreach (var e in _expectations.GetEntities(_cache)) {
      var expected = e.expectedDelivery;
      GameEntity packageEntity = null;
      var packages = _contexts.game.GetPackagesAtPosition(e.mapPosition.Value);
      if (packages.Count <= 0) ReportMissDelivery(e.mapPosition.Value, expected, null);
      else {
        packageEntity = packages.Any();
        if (packageEntity.package.Type != expected.Type) ReportMissDelivery(e.mapPosition.Value, expected, packageEntity.package);
      }

      DestroyPackage(packageEntity);
      e.Destroy();
    }

    if (_contexts.game.hasOutgoingCar) _contexts.game.RemoveOutgoingCar();
    if (_contexts.game.levelDeliveries.Packages.Count <= 0 && !_contexts.game.hasLevelFinished) _contexts.game.ReplaceLevelFinished(true);
  }

  void DestroyPackage(GameEntity package)
  {
    if (package == null) return;

    var holding = _contexts.game.GetEntityWithDroneHoldingPackageId(package.entityId.Value);
    holding?.Destroy();

    if (!package.isDestroyed) package.Destroy();
  }

  void ReportMissDelivery(Vector2Int location, ExpectedDeliveryComponent expectation, PackageComponent reality)
  {
    _contexts.service.loggingService.Instance.Error($"Delivery {location} failed. Reason: expecting [{expectation.Type}] but received [{(reality != null ? reality.Type : "Null")}]");
    _contexts.game.ReplaceSuspicion(_contexts.game.suspicion.Value + 20);
  }
}