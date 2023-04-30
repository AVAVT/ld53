using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[GameEvent]
public class TutorialNextEvent : IComponent
{
  public int Step;
}