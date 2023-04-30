using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class ReactiveStartGameSystem : ReactiveSystem<GameEventEntity>
{
  readonly Contexts _contexts;

  public ReactiveStartGameSystem(Contexts contexts) : base(contexts.gameEvent)
  {
    _contexts = contexts;
  }

  protected override ICollector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
  {
    return context.CreateCollector(GameEventMatcher.EventStartGame);
  }

  protected override bool Filter(GameEventEntity entity)
  {
    return true;
  }

  protected override void Execute(List<GameEventEntity> entities)
  {
    _contexts.game.ReplaceLevel(0);
    _contexts.game.ReplaceMainMenu(true);
    _contexts.service.gameManagerService.Instance.ChangeScene(SceneTag.Tutorial, 1f);
  }
}