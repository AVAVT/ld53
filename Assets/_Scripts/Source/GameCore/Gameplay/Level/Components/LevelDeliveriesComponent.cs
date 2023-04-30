using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LevelDeliveriesComponent : IComponent
{
  public List<PackageType> Packages;
  public int AmountPerDelivery;
  public int DeliveryInterval;
}