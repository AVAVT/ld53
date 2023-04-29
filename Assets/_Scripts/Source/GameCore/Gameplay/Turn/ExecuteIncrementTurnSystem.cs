using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class ExecuteIncrementTurnSystem : IInitializeSystem, IExecuteSystem
{
  readonly Contexts _contexts;
  GameEntity _timeEntity;
  GameEntity _turnEntity;
  readonly float _turnTime;

  public ExecuteIncrementTurnSystem(Contexts contexts)
  {
    _contexts = contexts;
    _turnTime = _contexts.config.gameplayConfig.Value.TurnTime;
  }

  public void Initialize()
  {
    _contexts.game.SetTurn(0);
    _turnEntity = _contexts.game.turnEntity;
    _turnEntity.AddExistInScene(SceneTag.Gameplay);

    _timeEntity = _contexts.game.timeEntity;
  }

  public void Execute()
  {
    var turn = Mathf.FloorToInt(_timeEntity.time.timeSinceLevelLoad / _turnTime);
    if (_turnEntity.turn.Value >= turn) return;

    _turnEntity.ReplaceTurn(turn);
  }
}