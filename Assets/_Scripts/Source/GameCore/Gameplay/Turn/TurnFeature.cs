public sealed class TurnFeature : Feature
{
  public TurnFeature(Contexts contexts) : base("TurnFeature")
  {
    Add(new ExecuteIncrementTurnSystem(contexts));
  }
}