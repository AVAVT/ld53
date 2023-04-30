using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Self)]
public class TutorialComponent : IComponent
{
  public int Step;
}