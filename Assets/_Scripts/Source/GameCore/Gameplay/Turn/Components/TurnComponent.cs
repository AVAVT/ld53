using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class TurnComponent : IComponent
{
  public int Value;
  public int PackageTurn => Value + 20;
}