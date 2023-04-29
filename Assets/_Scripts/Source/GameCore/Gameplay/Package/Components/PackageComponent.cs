using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class PackageComponent : IComponent
{
  public PackageType Type;
}