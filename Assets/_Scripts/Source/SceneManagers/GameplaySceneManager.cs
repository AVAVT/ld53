using Entitas;

namespace DevDef.SceneManagers
{
  public sealed class GameplaySceneManager : BaseSceneService
  {
    public override SceneTag SceneTag => SceneTag.Gameplay;
    protected override Systems CreateSystems() => new GameplaySceneFeature(_contexts);
  }
}