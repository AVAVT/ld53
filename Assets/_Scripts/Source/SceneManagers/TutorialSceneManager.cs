using Entitas;

namespace DevDef.SceneManagers
{
  public sealed class TutorialSceneManager : BaseSceneService
  {
    public override SceneTag SceneTag => SceneTag.Tutorial;
    protected override Systems CreateSystems() => new TutorialSceneFeature(_contexts);
  }
}