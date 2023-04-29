public sealed class MapFeature : Feature
{
  public MapFeature(Contexts contexts) : base("FeatureMap")
  {
    Add(new InitMapSystem(contexts));
    Add(new ExecuteMoveMapEntities(contexts));
  }
}