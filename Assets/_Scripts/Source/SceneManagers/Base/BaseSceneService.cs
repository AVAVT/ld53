namespace DevDef.SceneManagers
{
  public abstract class BaseSceneService : BaseSystemRunner, ISceneManagerService
  {
    protected override void Setup()
    {
      _contexts.service.ReplaceSceneManagerService(this);
      _contexts.game.ReplaceActiveScene(SceneTag);
    }

    public abstract SceneTag SceneTag { get; }
  }
}