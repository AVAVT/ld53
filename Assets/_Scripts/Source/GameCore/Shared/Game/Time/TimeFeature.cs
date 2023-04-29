public sealed class TimeFeature : Feature
{
  public TimeFeature(Contexts contexts) : base("TimeFeature")
  {
    Add(new TimeKeeperSystem(contexts));
    Add(new ResetTimeSinceLevelLoadSystem(contexts));
  }
}