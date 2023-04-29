using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ReactiveResolveTurnDecisionSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  readonly Vector2Int _halfMapSize;
  readonly IGroup<GameEntity> _packages;

  public ReactiveResolveTurnDecisionSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
    _halfMapSize = contexts.config.gameplayConfig.Value.BoardSize / 2;
    _packages = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Package, GameMatcher.MapPosition));
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.Turn);
  }

  protected override bool Filter(GameEntity entity)
  {
    return true;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    if (!_contexts.game.hasReceivedDecision) return; // TODO should game over here

    var receivedDecision = _contexts.game.receivedDecision;

    foreach (var droneDecision in receivedDecision.Decision.droneDecisions) {
      var drone = _contexts.game.GetEntityWithEntityId(droneDecision.id);
      var newPos = drone.mapPosition.Value + GeneralUtils.DroneMoveToDirVector(droneDecision.move);

      if (!GeneralUtils.IsPositionInMap(newPos, _halfMapSize)) {
        DestroyDrone(drone);
        continue;
      }

      drone.ReplaceMapPosition(newPos);
      drone.ReplaceDroneAction(droneDecision.move == Move.PickOrDrop ? DroneAction.PickDrop : DroneAction.Fly);

      var holding = _contexts.game.GetEntityWithDroneHoldingDroneId(drone.entityId.Value);

      if (holding != null) {
        var package = _contexts.game.GetEntityWithEntityId(holding.droneHolding.packageId);
        package.ReplaceMapPosition(newPos);

        if (droneDecision.move == Move.PickOrDrop) holding.Destroy();
      }
      else if (droneDecision.move == Move.PickOrDrop) {
        var packagesAtPosition = _contexts.game.GetPackagesAtPosition(newPos);
        if (packagesAtPosition.Count <= 0) continue;

        var package = packagesAtPosition.Any();
        _contexts.game.CreateEntity().AddDroneHolding(drone.entityId.Value, package.entityId.Value);
      }
    }

    foreach (var package in _packages) {
      if (package.isDestroyed) continue;

      var packagesAtPos = _contexts.game.GetPackagesAtPosition(package.mapPosition.Value);
      if (packagesAtPos.Count <= 1) continue;

      foreach (var pkg in packagesAtPos) DestroyPackage(pkg);
    }

    _contexts.game.RemoveReceivedDecision();
  }

  void DestroyDrone(GameEntity drone)
  {
    if (!drone.isDestroyed) {
      drone.isDestroyed = true;
    }

    var holding = _contexts.game.GetEntityWithDroneHoldingDroneId(drone.entityId.Value);
    if (holding == null) return;
    _contexts.game.GetEntityWithEntityId(holding.droneHolding.packageId).isDestroyed = true;
    holding.Destroy();
  }

  void DestroyPackage(GameEntity package)
  {
    if (!package.isDestroyed) {
      package.isDestroyed = true;
      package.RemoveMapPosition();
    }

    var holding = _contexts.game.GetEntityWithDroneHoldingPackageId(package.entityId.Value);
    if (holding == null) return;
    _contexts.game.GetEntityWithEntityId(holding.droneHolding.droneId).isDestroyed = true;
    holding.Destroy();
  }
}