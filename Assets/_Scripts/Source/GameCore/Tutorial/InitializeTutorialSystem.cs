using Entitas;

public class InitializeTutorialSystem : IInitializeSystem
{
  readonly Contexts _contexts;
  public InitializeTutorialSystem(Contexts contexts)
  {
    _contexts = contexts;
  }

  public void Initialize()
  {
    _contexts.game.SetTutorial(0);
    _contexts.game.tutorialEntity.AddExistInScene(SceneTag.Tutorial);
  }
}