using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class IncomingCarComponent : IComponent
{
  public List<PackageType> Packages;
}