namespace DevDef.SceneManagers
{
  public sealed class GameplaySceneFeature : Feature
  {
    public GameplaySceneFeature(Contexts contexts) : base("GameplaySceneFeature")
    {
      Add(new MapFeature(contexts));
      Add(new TurnFeature(contexts));
      Add(new LevelFeature(contexts));
      Add(new TurnDecisionFeature(contexts));
      Add(new DroneFeature(contexts));
      Add(new PackageFeature(contexts));
      Add(new SuspicionFeature(contexts));
      Add(new ExplosionFeature(contexts));
    }
  }
}