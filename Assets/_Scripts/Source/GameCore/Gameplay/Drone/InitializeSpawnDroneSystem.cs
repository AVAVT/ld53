using System.Collections.Generic;
using Entitas;

public class InitializeSpawnDroneSystem : IInitializeSystem
{
  readonly Contexts _contexts;
  public InitializeSpawnDroneSystem(Contexts contexts)
  {
    _contexts = contexts;
  }

  public void Initialize()
  {
    var levelConfig = _contexts.config.gameplayConfig.Value.Levels[_contexts.game.level.Value];

    foreach (var location in levelConfig.Drones) {
      var drone = _contexts.game.CreateEntity();
      drone.isDrone = true;
      drone.AddExistInScene(SceneTag.Gameplay);
      drone.AddMapPosition(location);
      drone.AddDroneAction(DroneAction.Fly);
    }
  }
}