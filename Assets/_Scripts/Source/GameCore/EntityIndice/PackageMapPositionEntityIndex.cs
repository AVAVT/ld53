using System;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public struct MapPositionIndex : IEquatable<MapPositionIndex>
{
  public int X;
  public int Y;

  public MapPositionIndex(Vector2Int position)
  {
    X = position.x;
    Y = position.y;
  }

  public bool Equals(MapPositionIndex other)
  {
    return other.X == X && other.Y == Y;
  }

  public override bool Equals(object obj)
  {
    if (obj == null || obj.GetType() != GetType() || obj.GetHashCode() != GetHashCode()) {
      return false;
    }

    var other = (MapPositionIndex)obj;
    return other.X == X && other.Y == Y;
  }

  public override int GetHashCode()
  {
    var hashCode = 1502939027;
    hashCode = hashCode * -1521134295 + X.GetHashCode();
    hashCode = hashCode * -152134295 + Y.GetHashCode();
    return hashCode;
  }
}

[CustomEntityIndex(typeof(GameContext))]
public class PackageMapPositionEntityIndex : EntityIndex<GameEntity, MapPositionIndex>
{
  public PackageMapPositionEntityIndex(GameContext context) : base(
    nameof(PackageMapPositionEntityIndex),
    context.GetGroup(Matcher<GameEntity>.AllOf(
      GameMatcher.Package, GameMatcher.MapPosition).NoneOf(GameMatcher.Destroyed)), (entity, component) => {
      var position = component as MapPositionComponent ?? entity.mapPosition;
      return new(position.Value);
    }
  )
  {
  }

  [EntityIndexGetMethod]
  public HashSet<GameEntity> GetPackagesAtPosition(Vector2Int position)
  {
    return GetEntities(new(position));
  }
}