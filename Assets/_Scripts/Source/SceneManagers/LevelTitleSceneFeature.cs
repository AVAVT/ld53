namespace DevDef.SceneManagers
{
  public sealed class LevelTitleSceneFeature : Feature
  {
    public LevelTitleSceneFeature(Contexts contexts) : base("LevelTitleSceneFeature")
    {
      Add(new InitializeLevelTitleSystem(contexts));
      Add(new ExecuteMoveToGameplaySystem(contexts));
    }
  }
}