using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any), Event(EventTarget.Any, EventType.Removed)]
public class OutgoingCarComponent : IComponent
{
  public List<PackageType> Expects;
}