public sealed class MainMenuFeature : Feature
{
  public MainMenuFeature(Contexts contexts) : base("MainMenuFeature")
  {
    Add(new InitMainMenuSystem(contexts));
    Add(new ReactiveStartGameSystem(contexts));
  }
}