using System.Collections.Generic;
using Entitas;

public class ReactiveSpawnIncomingCarSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  readonly int _deliveryInterval;
  public ReactiveSpawnIncomingCarSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
    _deliveryInterval = contexts.config.gameplayConfig.Value.DeliveryInterval;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.Turn);
  }

  protected override bool Filter(GameEntity entity)
  {
    return (entity.turn.PackageTurn + 3) % _deliveryInterval == 0;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    if (_contexts.game.hasLevelFinished) return;

    var numberToTake = _contexts.game.levelPackages.AmountPerIncoming;
    List<PackageType> packages = new();
    while (numberToTake > 0 && _contexts.game.levelPackages.Packages.Count > 0) {
      packages.Add(_contexts.game.levelPackages.Packages.RemoveRandom());
      numberToTake--;
    }

    var car = _contexts.game.CreateEntity();
    car.AddIncomingCar(packages);
    car.AddExistInScene(SceneTag.Gameplay);
  }
}