using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class DroneHoldingComponent : IComponent
{
  [PrimaryEntityIndex]
  public int droneId;

  [PrimaryEntityIndex]
  public int packageId;
}