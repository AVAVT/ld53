using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class MenuIndexComponent : IComponent
{
  public int Value;
}