using UnityEngine;

public static class BfsUtils
{
  public static readonly Vector2Int EmptyValue = Vector2Int.one * -int.MaxValue;
  public static bool IsDirectionValid(Vector2Int dir) => dir.sqrMagnitude < 4;

  public static bool IsPositionValid(Vector2Int pos, Vector2Int mapSize) =>
    pos.x >= 0 && pos.x < mapSize.x && pos.y >= 0 && pos.y < mapSize.y;
}