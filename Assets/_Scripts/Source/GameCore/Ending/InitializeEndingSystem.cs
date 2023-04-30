using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class InitializeEndingSystem : IInitializeSystem
{
  readonly Contexts _contexts;
  public InitializeEndingSystem(Contexts contexts)
  {
    _contexts = contexts;
  }

  public void Initialize()
  {
    _contexts.game.SetEnding(0);
    _contexts.game.endingEntity.AddExistInScene(SceneTag.Ending);
    if (_contexts.game.hasLevelFinished) _contexts.game.RemoveLevelFinished();
  }
}