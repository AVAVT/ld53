using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class ReactiveIncomingCarDestroyPackagesSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  readonly int _deliveryInterval;
  readonly int _minDestroyX;
  readonly int _maxDestroyX;
  readonly IGroup<GameEntity> _packages;
  readonly List<GameEntity> _packageCache = new();
  public ReactiveIncomingCarDestroyPackagesSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
    _deliveryInterval = contexts.config.gameplayConfig.Value.DeliveryInterval;
    var spawnLocations = contexts.config.gameplayConfig.Value.IncomingZone;
    _minDestroyX = spawnLocations.Min(loc => loc.x);
    _maxDestroyX = spawnLocations.Max(loc => loc.x);
    _packages = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Package, GameMatcher.MapPosition).NoneOf(GameMatcher.Destroyed));
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.Turn);
  }

  protected override bool Filter(GameEntity entity)
  {
    return (entity.turn.PackageTurn + 1) % _deliveryInterval == 0;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var pkg in _packages.GetEntities(_packageCache)) {
      if (pkg.mapPosition.Value.x < _minDestroyX || pkg.mapPosition.Value.x > _maxDestroyX) continue;

      _contexts.service.loggingService.Instance.Error($"Package {pkg.entityId.Value} destroyed. Reason: collision with delivery car.");
      DestroyPackage(pkg);
    }
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