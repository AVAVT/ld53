public sealed class SuspicionFeature : Feature
{
  public SuspicionFeature(Contexts contexts) : base("SuspicionFeature")
  {
    Add(new InitializeSuspicionSystem(contexts));
    Add(new ReactiveGameOverSuspicionSystem(contexts));
  }
}