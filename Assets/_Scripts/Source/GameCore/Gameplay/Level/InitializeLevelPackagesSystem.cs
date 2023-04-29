using System.Collections.Generic;
using Entitas;

public class InitializeLevelPackagesSystem : IInitializeSystem
{
  readonly Contexts _contexts;
  public InitializeLevelPackagesSystem(Contexts contexts)
  {
    _contexts = contexts;
  }

  public void Initialize()
  {
    if (_contexts.game.hasLevelFinished) _contexts.game.RemoveLevelFinished();

    var levelConfig = _contexts.config.gameplayConfig.Value.Levels[_contexts.game.level.Value];
    var levelPackages = new List<PackageType>();
    for (var i = 0; i < levelConfig.Red; i++) levelPackages.Add(PackageType.Red);
    for (var i = 0; i < levelConfig.Green; i++) levelPackages.Add(PackageType.Green);
    for (var i = 0; i < levelConfig.Blue; i++) levelPackages.Add(PackageType.Blue);
    for (var i = 0; i < levelConfig.Purple; i++) levelPackages.Add(PackageType.Purple);

    _contexts.game.ReplaceLevelPackages(levelPackages, levelConfig.ItemPerWave);
  }
}