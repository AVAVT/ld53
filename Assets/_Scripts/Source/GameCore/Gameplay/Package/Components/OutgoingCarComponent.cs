using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class OutgoingCarComponent : IComponent
{
  public List<PackageType> Expects;
}