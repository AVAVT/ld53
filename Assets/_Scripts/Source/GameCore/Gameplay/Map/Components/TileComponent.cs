using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class TileComponent : IComponent
{
    [PrimaryEntityIndex]
    public Vector2Int Position;
    public bool Droppable;
}