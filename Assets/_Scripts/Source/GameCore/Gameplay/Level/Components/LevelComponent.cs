﻿using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LevelComponent : IComponent
{
  public int Value;
}