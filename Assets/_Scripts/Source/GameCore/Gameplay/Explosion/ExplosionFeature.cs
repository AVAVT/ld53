public sealed class ExplosionFeature : Feature
{
  public ExplosionFeature(Contexts contexts) : base("ExplosionFeature")
  {
    Add(new ReactiveCreatePackageExplosion(contexts));
  }
}