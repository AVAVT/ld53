﻿using System;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class MapInfoComponent : IComponent
{
  public TileInfoDto[] Tiles;
}