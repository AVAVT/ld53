public sealed class PackageFeature : Feature
{
  public PackageFeature(Contexts contexts) : base("PackageFeature")
  {
    Add(new ReactiveRemovePackageHoldSystem(contexts));
    Add(new ReactiveSpawnIncomingCarSystem(contexts));
    Add(new ReactiveIncomingCarDestroyPackagesSystem(contexts));
    Add(new ReactiveSpawnPackageSystem(contexts));
    Add(new ReactiveSpawnOutgoingCarSystem(contexts));
    Add(new ReactivePerformDeliverySystem(contexts));
  }
}