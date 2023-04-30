namespace DevDef.SceneManagers
{
  public sealed class EndingSceneFeature : Feature
  {
    public EndingSceneFeature(Contexts contexts) : base("EndingSceneFeature")
    {
      Add(new EndingFeature(contexts));
    }
  }
}