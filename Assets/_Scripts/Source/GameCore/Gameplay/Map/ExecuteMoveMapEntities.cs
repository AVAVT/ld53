using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class ExecuteMoveMapEntities : IExecuteSystem
{
    readonly Contexts _contexts;
    readonly IGroup<GameEntity> _mapEntities;

    const float RATIO = 60;
    readonly float _turnTime;

    public ExecuteMoveMapEntities(Contexts contexts)
    {
        _contexts = contexts;
        _turnTime = contexts.config.gameplayConfig.Value.TurnTime;
        _mapEntities = _contexts.game.GetGroup(GameMatcher.MapPosition);
    }

    public void Execute()
    {
        var moveByTurn = _contexts.game.time.deltaTime * RATIO / _turnTime;
        var moveByTurnSqr = moveByTurn * moveByTurn;
        foreach (var entity in _mapEntities)
        {
            var targetPosition = (Vector2)entity.mapPosition.Value * RATIO;
            if (!entity.hasPosition) entity.AddPosition(targetPosition);
            else if (entity.position.Value != targetPosition)
            {
                var diff = targetPosition - entity.position.Value;
                if (diff.sqrMagnitude > moveByTurnSqr)
                    entity.ReplacePosition(entity.position.Value + diff.ApproxClampMagnitude(moveByTurn));
                else entity.ReplacePosition(targetPosition);
            }
        }
    }
}