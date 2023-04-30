using Entitas;

namespace DevDef.SceneManagers
{
  public sealed class LevelTitleSceneManager : BaseSceneService
  {
    public override SceneTag SceneTag => SceneTag.LevelTitle;
    protected override Systems CreateSystems() => new LevelTitleSceneFeature(_contexts);
  }
}