public sealed class TurnDecisionFeature : Feature
{
  public TurnDecisionFeature(Contexts contexts) : base("TurnDecisionFeature")
  {
    Add(new ReactiveResolveTurnDecisionSystem(contexts));
    Add(new ReactiveTurnRequestDecision(contexts));
  }
}