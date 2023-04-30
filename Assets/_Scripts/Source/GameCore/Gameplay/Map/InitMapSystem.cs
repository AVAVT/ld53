using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InitMapSystem : IInitializeSystem
{
  readonly Contexts _contexts;

  public InitMapSystem(Contexts contexts)
  {
    _contexts = contexts;
  }

  public void Initialize()
  {
    var config = _contexts.config.gameplayConfig.Value;
    var halfWidth = config.BoardSize.x / 2;
    var halfHeight = config.BoardSize.y / 2;
    var halfStorageWidth = config.StorageZone.x / 2;
    var halfStorageHeight = config.StorageZone.y / 2;
    var outgoingZone = config.OutgoingZone;

    List<TileInfoDto> tiles = new();
    for (var x = -halfWidth; x <= halfWidth; x++) {
      for (var y = -halfHeight; y <= halfHeight; y++) {
        var tile = _contexts.game.CreateEntity();
        tile.AddExistInScene(SceneTag.Gameplay);
        tile.AddTile(
          new(x, y),
          IsLocationADropZone(x, y, halfStorageWidth, halfStorageHeight, outgoingZone)
        );
        tiles.Add(new()
        {
          x = x,
          y = y,
          droppable = tile.tile.Droppable
        });
      }
    }

    _contexts.game.ReplaceMapInfo(tiles.ToArray());
  }

  static bool IsLocationADropZone(int x, int y, int halfStorageWidth, int halfStorageHeight, List<Vector2Int> outcomingZone) =>
    (x != 0 && y != 0 && Mathf.Abs(x) <= halfStorageWidth && Mathf.Abs(y) <= halfStorageHeight) || outcomingZone.Contains(new(x, y));
}