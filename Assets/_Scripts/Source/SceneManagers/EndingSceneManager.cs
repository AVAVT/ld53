using Entitas;

namespace DevDef.SceneManagers
{
  public sealed class EndingSceneManager : BaseSceneService
  {
    public override SceneTag SceneTag => SceneTag.Ending;
    protected override Systems CreateSystems() => new EndingSceneFeature(_contexts);
  }
}