namespace DevDef.SceneManagers
{
  public sealed class MainMenuSceneFeature : Feature
  {
    public MainMenuSceneFeature(Contexts contexts) : base("MainMenuSceneFeature")
    {
      Add(new MainMenuFeature(contexts));
    }
  }
}