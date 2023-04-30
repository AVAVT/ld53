using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entitas;

public class ReactiveTurnRequestDecision : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  readonly IAiService _aiService;
  readonly IGroup<GameEntity> _drones;
  readonly IGroup<GameEntity> _packages;
  public ReactiveTurnRequestDecision(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
    _aiService = contexts.service.aIService.Instance;
    _drones = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Drone).NoneOf(GameMatcher.Destroyed));
    _packages = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Package).NoneOf(GameMatcher.Destroyed));
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
    if (_contexts.game.hasLevelFinished) return;

    DoTurn(new()
    {
      turn = _contexts.game.turn.Value,
      tiles = _contexts.game.mapInfo.Tiles,
      drones = _drones.AsEnumerable().Select(drone => new DroneStateDto
      {
        x = drone.mapPosition.Value.x,
        y = drone.mapPosition.Value.y,
        id = drone.entityId.Value,
        holding = _contexts.game.GetEntityWithDroneHoldingDroneId(drone.entityId.Value)?.droneHolding.packageId
      }).ToArray(),
      packages = _packages.AsEnumerable().Select(package => new PackageStateDto
      {
        x = package.mapPosition.Value.x,
        y = package.mapPosition.Value.y,
        id = package.entityId.Value,
        heldBy = _contexts.game.GetEntityWithDroneHoldingPackageId(package.entityId.Value)?.droneHolding.droneId
      }).ToArray()
    }).ConfigureAwait(false);
  }

  async Task DoTurn(TurnStateDto turnState)
  {
    try {
      var decision = await _aiService.DoTurn(turnState);
      _contexts.game.SetReceivedDecision(turnState.turn, decision);
    }
    catch (Exception e) {
      _contexts.service.loggingService.Instance.Error(e);
    }
  }
}