using System;
using UnityEngine;

public static class GeneralUtils
{
  public static Vector2Int DroneMoveToDirVector(Move dir) => dir switch
  {
    Move.PickOrDrop => Vector2Int.zero,
    Move.Up => Vector2Int.up,
    Move.Right => Vector2Int.right,
    Move.Down => Vector2Int.down,
    Move.Left => Vector2Int.left,
    _ => throw new ArgumentOutOfRangeException(nameof(dir), dir, null)
  };

  public static bool IsPositionInMap(Vector2Int pos, Vector2Int halfMap) => Mathf.Abs(pos.x) <= halfMap.x && Mathf.Abs(pos.y) <= halfMap.y;
}