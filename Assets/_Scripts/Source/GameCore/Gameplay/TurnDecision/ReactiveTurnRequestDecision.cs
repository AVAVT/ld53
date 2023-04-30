using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entitas;
using UnityEngine;

public class ReactiveTurnRequestDecision : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  readonly IAiService _aiService;
  readonly IGroup<GameEntity> _drones;
  readonly IGroup<GameEntity> _packages;
  readonly IGroup<GameEntity> _expectedDeliveries;
  readonly LevelConfigModel _levelConfig;
  readonly GameplayConfigModel _gameplayConfig;
  public ReactiveTurnRequestDecision(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
    _aiService = contexts.service.aIService.Instance;
    _drones = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Drone).NoneOf(GameMatcher.Destroyed));
    _packages = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Package).NoneOf(GameMatcher.Destroyed));
    _expectedDeliveries = contexts.game.GetGroup(GameMatcher.ExpectedDelivery);
    _gameplayConfig = contexts.config.gameplayConfig.Value;
    _levelConfig = _gameplayConfig.Levels[_contexts.game.level.Value];
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
      mapWidth = _gameplayConfig.BoardSize.x,
      mapHeight = _gameplayConfig.BoardSize.y,
      turn = _contexts.game.turn.Value,

      // TODO Jam code, beautify
      nextDeliveryAt = Mathf.Max(_levelConfig.FirstDeliveryBuffer + _levelConfig.DeliveryInterval, _contexts.game.turn.Value + (_levelConfig.DeliveryInterval - (_contexts.game.turn.Value - _levelConfig.FirstDeliveryBuffer) % _levelConfig.DeliveryInterval)),
      nextIncomingAt = _contexts.game.turn.Value + (_gameplayConfig.ImportInterval - (_contexts.game.turn.IncomingTurn % _gameplayConfig.ImportInterval)),
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
        type = package.package.Type,
        heldBy = _contexts.game.GetEntityWithDroneHoldingPackageId(package.entityId.Value)?.droneHolding.droneId
      }).ToArray(),
      expectedDeliveries = _expectedDeliveries.AsEnumerable().Select(e => new ExpectedDeliveryDto
      {
        x = e.mapPosition.Value.x,
        y = e.mapPosition.Value.y,
        type = e.expectedDelivery.Type
      }).ToArray()
    }).ConfigureAwait(false);
  }

  async Task DoTurn(TurnStateDto turnState)
  {
    try {
      var decision = await _aiService.DoTurn(turnState);
      _contexts.game.SetReceivedDecision(turnState.turn, decision);
      _contexts.game.receivedDecisionEntity.AddExistInScene(SceneTag.Gameplay);
    }
    catch (Exception e) {
      _contexts.service.loggingService.Instance.Error(e);
    }
  }
}