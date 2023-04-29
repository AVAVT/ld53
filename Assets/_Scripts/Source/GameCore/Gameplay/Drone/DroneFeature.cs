public sealed class DroneFeature : Feature
{
  public DroneFeature(Contexts contexts) : base("DroneFeature")
  {
    Add(new InitializeSpawnDroneSystem(contexts));
    Add(new ReactiveRemoveDroneHoldSystem(contexts));
  }
}