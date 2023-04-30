namespace DevDef.SceneManagers
{
  public sealed class TutorialSceneFeature : Feature
  {
    public TutorialSceneFeature(Contexts contexts) : base("TutorialSceneFeature")
    {
      Add(new TutorialFeature(contexts));
    }
  }
}