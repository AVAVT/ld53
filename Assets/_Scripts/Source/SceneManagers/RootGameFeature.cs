namespace DevDef.SceneManagers
{
  public sealed class RootGameFeature : Feature
  {
    public RootGameFeature(Contexts contexts) : base("RootFeature")
    {
      Add(new TimeFeature(contexts));

      Add(new CoreFeature(contexts));
      Add(new CleanEntityBySceneSystem(contexts));

      // Generated Systems
      Add(new GameEventSystems(contexts));
      Add(new GameCleanupSystems(contexts));
      Add(new CleanupAllGameEventEntitiesSystem(contexts));
    }
  }
}