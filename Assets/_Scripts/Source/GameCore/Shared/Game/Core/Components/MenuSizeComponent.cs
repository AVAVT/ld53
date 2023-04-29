using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class MenuSizeComponent : IComponent
{
  public int Value;
}