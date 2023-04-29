using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LevelPackagesComponent : IComponent
{
  public List<PackageType> Packages;
  public int AmountPerIncoming;
}