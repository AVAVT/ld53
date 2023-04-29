public sealed class LevelFeature : Feature
{
  public LevelFeature(Contexts contexts) : base("LevelFeature")
  {
    Add(new InitializeLevelPackagesSystem(contexts));
  }
}