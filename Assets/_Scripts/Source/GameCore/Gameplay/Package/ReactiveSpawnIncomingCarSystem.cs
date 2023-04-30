using System.Collections.Generic;
using Entitas;

public class ReactiveSpawnIncomingCarSystem : ReactiveSystem<GameEntity>
{
  readonly Contexts _contexts;
  readonly int _importInterval;
  public ReactiveSpawnIncomingCarSystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
    _importInterval = contexts.config.gameplayConfig.Value.ImportInterval;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.Turn);
  }

  protected override bool Filter(GameEntity entity)
  {
    return (entity.turn.IncomingTurn + 3) % _importInterval == 0;
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