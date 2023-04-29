using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class TurnComponent : IComponent
{
  public int Value;
  public int PackageTurn => Value + 20;
}