using Entitas;

public class InitializeLevelTitleSystem : IInitializeSystem
{
  readonly Contexts _contexts;
  public InitializeLevelTitleSystem(Contexts contexts)
  {
    _contexts = contexts;
  }

  public void Initialize()
  {
    _contexts.game.isLevelTitle = true;
    _contexts.game.levelTitleEntity.AddExistInScene(SceneTag.LevelTitle);
  }
}