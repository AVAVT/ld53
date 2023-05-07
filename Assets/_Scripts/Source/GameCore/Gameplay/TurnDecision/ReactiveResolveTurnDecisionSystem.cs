using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class ReactiveResolveTurnDecisionSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  readonly Vector2Int _halfMapSize;
  readonly IGroup<GameEntity> _packages;
  readonly IGroup<GameEntity> _livingDrones;
  readonly List<GameEntity> _packageCache = new();

  public ReactiveResolveTurnDecisionSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
    _halfMapSize = contexts.config.gameplayConfig.Value.BoardSize / 2;
    _packages = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Package, GameMatcher.MapPosition));
    _livingDrones = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Drone).NoneOf(GameMatcher.Destroyed));
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
    if (!_contexts.game.hasReceivedDecision) {
      if (_contexts.game.turn.Value > 0) _contexts.game.ReplaceLevelFinished(false);
      return;
    }
    var receivedDecision = _contexts.game.receivedDecision;

    Dictionary<int, DroneDecision> decisions = new();

    foreach (var droneDecision in receivedDecision.Decision.droneDecisions) {
      if (decisions.ContainsKey(droneDecision.id)) {
        decisions.Remove(droneDecision.id);
        var drone = _contexts.game.GetEntityWithEntityId(droneDecision.id);
        if (drone is not { isDrone: true }) continue;

        _contexts.service.loggingService.Instance.Error($"Drone {drone.entityId.Value} eliminated. Reason: multiple commands received in the same turn.");
        _contexts.game.ReplaceSuspicion(_contexts.game.suspicion.Value + 20);
        DestroyDrone(drone);
      }

      decisions.Add(droneDecision.id, droneDecision);
    }

    foreach (var droneDecision in decisions.Values) {
      var drone = _contexts.game.GetEntityWithEntityId(droneDecision.id);
      if (drone is not { isDrone: true }) {
        _contexts.service.loggingService.Instance.Error($"Error: Drone {droneDecision.id} does not exist.");
        _contexts.game.ReplaceSuspicion(_contexts.game.suspicion.Value + 20);
        continue;
      }
      if (drone.isDestroyed) continue;

      var newPos = drone.mapPosition.Value + GeneralUtils.DroneMoveToDirVector(droneDecision.move);

      if (!GeneralUtils.IsPositionInMap(newPos, _halfMapSize)) {
        _contexts.service.loggingService.Instance.Error($"Drone {drone.entityId.Value} eliminated. Reason: wandering out of bounds.");
        _contexts.game.ReplaceSuspicion(_contexts.game.suspicion.Value + 20);
        DestroyDrone(drone);
        continue;
      }

      drone.ReplaceMapPosition(newPos);
      drone.ReplaceDroneAction(droneDecision.move == Move.PickOrDrop ? DroneAction.PickDrop : DroneAction.Fly);

      var holding = _contexts.game.GetEntityWithDroneHoldingDroneId(drone.entityId.Value);

      if (holding != null) {
        var package = _contexts.game.GetEntityWithEntityId(holding.droneHolding.packageId);
        package.ReplaceMapPosition(newPos);

        if (droneDecision.move != Move.PickOrDrop) continue;
        holding.Destroy();
        if (_contexts.game.GetEntityWithTile(newPos).tile.Droppable) continue;
        DestroyPackage(package);
        _contexts.service.loggingService.Instance.Error($"Package {package.entityId.Value} destroyed. Reason: drop off in forbidden area.");
        _contexts.game.ReplaceSuspicion(_contexts.game.suspicion.Value + 20);
      }
      else if (droneDecision.move == Move.PickOrDrop) {
        var packagesAtPosition = _contexts.game.GetPackagesAtPosition(newPos);
        if (packagesAtPosition.Count <= 0) continue;

        var pkg = packagesAtPosition.Any();

        var hd = _contexts.game.GetEntityWithDroneHoldingPackageId(pkg.entityId.Value);
        if (hd != null) {
          _contexts.service.loggingService.Instance.Error($"Package {pkg.entityId.Value} destroyed. Reason: multiple drones pickup.");
          _contexts.game.ReplaceSuspicion(_contexts.game.suspicion.Value + 20);
          DestroyPackage(pkg);
          continue;
        }

        _contexts.game.CreateEntity().AddDroneHolding(drone.entityId.Value, pkg.entityId.Value);
      }
    }

    foreach (var package in _packages.GetEntities(_packageCache)) {
      if (package.isDestroyed) continue;

      var packagesAtPos = _contexts.game.GetPackagesAtPosition(package.mapPosition.Value);
      if (packagesAtPos.Count <= 1) continue;

      foreach (var pkg in packagesAtPos.ToArray()) {
        DestroyPackage(pkg);
        _contexts.service.loggingService.Instance.Error($"Package {pkg.entityId.Value} destroyed. Reason: collision with another package.");
        _contexts.game.ReplaceSuspicion(_contexts.game.suspicion.Value + 20);
      }
    }

    _contexts.game.RemoveReceivedDecision();

    if (_livingDrones.count <= 0) {
      _contexts.game.ReplaceLevelFinished(false);
    }
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
    }

    var holding = _contexts.game.GetEntityWithDroneHoldingPackageId(package.entityId.Value);
    if (holding == null) return;
    _contexts.game.GetEntityWithEntityId(holding.droneHolding.droneId).isDestroyed = true;
    holding.Destroy();
  }
}