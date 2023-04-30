public sealed class EndingFeature : Feature
{
  public EndingFeature(Contexts contexts) : base("EndingFeature")
  {
    Add(new InitializeEndingSystem(contexts));
    Add(new ReactiveEndingNextStep(contexts));
  }
}