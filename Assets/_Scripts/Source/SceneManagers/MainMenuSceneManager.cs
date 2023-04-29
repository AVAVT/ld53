using Entitas;

namespace DevDef.SceneManagers
{
  public sealed class MainMenuSceneManager : BaseSceneService
  {
    public override SceneTag SceneTag => SceneTag.MainMenu;
    protected override Systems CreateSystems() => new MainMenuSceneFeature(_contexts);
  }
}