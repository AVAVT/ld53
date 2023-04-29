using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class MapPositionComponent : IComponent
{
    public Vector2Int Value;
}