using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ReceivedDecisionComponent : IComponent
{
  public int Turn;
  public TurnDecision Decision;
}