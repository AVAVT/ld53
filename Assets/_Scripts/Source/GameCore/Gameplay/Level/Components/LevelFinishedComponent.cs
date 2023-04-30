using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LevelFinishedComponent : IComponent
{
  public bool IsVictory;
}