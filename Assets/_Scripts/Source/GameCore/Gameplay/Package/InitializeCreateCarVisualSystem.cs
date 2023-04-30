using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class InitializeCreateCarVisualSystem : IInitializeSystem
{
  readonly Contexts _contexts;
  public InitializeCreateCarVisualSystem(Contexts contexts)
  {
    _contexts = contexts;
  }

  public void Initialize()
  {
    var incoming = _contexts.game.CreateEntity();
    incoming.isIncomingCarVisual = true;
    incoming.AddExistInScene(SceneTag.Gameplay);

    var outgoing = _contexts.game.CreateEntity();
    outgoing.isOutgoingCarVisual = true;
    outgoing.AddExistInScene(SceneTag.Gameplay);
  }
}