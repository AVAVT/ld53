using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class ReactiveTutorialNextStep : ReactiveSystem<GameEventEntity>
{
  readonly Contexts _contexts;
  int _failureCount = 0;
  public ReactiveTutorialNextStep(Contexts contexts) : base(contexts.gameEvent)
  {
    _contexts = contexts;
  }

  protected override ICollector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
  {
    return context.CreateCollector(GameEventMatcher.TutorialNextEvent);
  }

  protected override bool Filter(GameEventEntity entity)
  {
    return entity.hasTutorialNextEvent;
  }

  protected override void Execute(List<GameEventEntity> entities)
  {
    foreach (var entity in entities) {
      if (entity.tutorialNextEvent.Step != _contexts.game.tutorial.Step) continue;

      if (entity.tutorialNextEvent.Step == 17) _contexts.service.gameManagerService.Instance.ChangeScene(SceneTag.LevelTitle, 0.5f);

      if (entity.tutorialNextEvent.Step is 9 or 12 or 14) {
        _contexts.game.ReplaceTutorial(10);
        DoCaptcha().ConfigureAwait(false);
      }
      else {
        _contexts.game.ReplaceTutorial(_contexts.game.tutorial.Step + 1);
      }
    }
  }

  async Task DoCaptcha()
  {
    try {
      var answer = await _contexts.service.aIService.Instance.Captcha("00110011 00110101 01011110 00110111 00100000 00111101 00100000 00111111");
      var isCorrect = answer is "00110110 00110100 00110011 00110011 00111001 00110010 00111001 00110110 00111000 00110111 00110101" or "111011111010111010111100001001101011";
      if (!isCorrect) _failureCount++;
      _contexts.game.ReplaceTutorial(isCorrect ? 15 : _failureCount >= 3 ? 13 : 11);
    }
    catch (Exception e) {
      _contexts.service.loggingService.Instance.Error(e);
    }
  }
}