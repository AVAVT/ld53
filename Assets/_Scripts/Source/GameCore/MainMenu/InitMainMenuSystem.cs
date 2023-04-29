using Entitas;

public class InitMainMenuSystem : IInitializeSystem
{
    readonly Contexts _contexts;

    public InitMainMenuSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.game.isMainMenu = true;
        _contexts.game.mainMenuEntity.AddExistInScene((SceneTag.MainMenu));
    }
}