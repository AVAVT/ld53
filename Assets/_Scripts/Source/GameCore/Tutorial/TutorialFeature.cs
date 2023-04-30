public sealed class TutorialFeature : Feature
{
  public TutorialFeature(Contexts contexts) : base("TutorialFeature")
  {
    Add(new InitializeTutorialSystem(contexts));
    Add(new ReactiveTutorialNextStep(contexts));
  }
}