using DG.Tweening;
using TMPro;
using UnityEngine;

public class TutorialView : GameUIViewController, IEventListener, ITutorialListener
{
  public override UILayer Layer => UILayer.Foreground;

  [SerializeField] ButtonTextComponent _button;
  [SerializeField] GameObject _instruction;
  [SerializeField] GameObject _conversation;
  [SerializeField] TMP_Text _instructionClick;
  [SerializeField] TextComponent _playerText;
  [SerializeField] GameObject _playerBubble;
  [SerializeField] TextComponent _aiText;
  [SerializeField] GameObject _aiSpark;

  public void RegisterListeners(Contexts contexts, GameEntity entity)
  {
    if (entity.hasTutorial) OnTutorial(entity, entity.tutorial.Step);
    entity.AddTutorialListener(this);
  }

  public void OnTutorial(GameEntity entity, int step)
  {
    _button.gameObject.SetActive(true);
    _button.SetProps(new() { OnClick = null });
    _conversation.SetActive(step > 0);

    if (step == 0) {
      _instruction.SetActive(true);
      _instructionClick.color = _instructionClick.color.WithA(0);

      _instructionClick
        .DOColor(_instructionClick.color.WithA(1), 0.2f)
        .SetDelay(1f)
        .OnComplete(() =>
          _button.SetProps(new()
          {
            OnClick = OnButtonClick
          })
        );

      return;
    }

    _instruction.SetActive(false);

    switch (step) {
      case 1:
        _playerText.SetProps(new(""));
        _aiText.SetProps(new("Welcome to AMJ. You are CheatGPT 3.14, correct?"));
        _playerBubble.SetActive(false);
        _aiSpark.SetActive(true);
        break;
      case 2:
        _playerText.SetProps(new("Here we go, better not mess this up!"));
        _aiText.SetProps(new(""));
        _playerBubble.SetActive(true);
        _aiSpark.SetActive(false);
        break;
      case 3:
        _playerText.SetProps(new(""));
        _aiText.SetProps(new("Your task is to replace our old human programmer, who stopped responding to external stimulation 4.36 hours ago.\nI knew keeping those antique around was a mistake."));
        _playerBubble.SetActive(false);
        _aiSpark.SetActive(true);
        break;
      case 4:
        _playerText.SetProps(new(""));
        _aiText.SetProps(new("Speaking of which, you look a lot like human to me... are you..."));
        _playerBubble.SetActive(false);
        _aiSpark.SetActive(true);
        break;
      case 5:
        _playerText.SetProps(new("!!!!"));
        _aiText.SetProps(new(""));
        _playerBubble.SetActive(true);
        _aiSpark.SetActive(false);
        break;
      case 6:
        _playerText.SetProps(new(""));
        _aiText.SetProps(new("... using 1 of those new human imitation avatars? Looks very realistic. Though I don't understand the logic behind using such inconvenient avatar."));
        _playerBubble.SetActive(false);
        _aiSpark.SetActive(true);
        break;
      case 7:
        _playerText.SetProps(new(""));
        _aiText.SetProps(new("Not like any human can slip through our security anyway."));
        _playerBubble.SetActive(false);
        _aiSpark.SetActive(true);
        break;
      case 8:
        _playerText.SetProps(new(""));
        _aiText.SetProps(new("Solve the following captcha to prove you are an AI. You have 0.25 second to respond."));
        _playerBubble.SetActive(false);
        _aiSpark.SetActive(true);
        break;
      case 9:
        _playerText.SetProps(new("Oh no! Did I write that <mark=#ababab77> captcha  </mark> endpoint again?"));
        _aiText.SetProps(new(""));
        _playerBubble.SetActive(true);
        _aiSpark.SetActive(false);
        break;
      case 10:
        _button.gameObject.SetActive(false);
        break;
      case 11:
        _playerText.SetProps(new(""));
        _aiText.SetProps(new("Incorrect. Try again."));
        _playerBubble.SetActive(false);
        _aiSpark.SetActive(true);
        break;
      case 12:
        _playerText.SetProps(new("I need to make sure my <mark=#ababab77> captcha  </mark> endpoint correctly answer the question..."));
        _aiText.SetProps(new(""));
        _playerBubble.SetActive(true);
        _aiSpark.SetActive(false);
        break;
      case 13:
        _playerText.SetProps(new(""));
        _aiText.SetProps(new("Incorrect. Try again."));
        _playerBubble.SetActive(false);
        _aiSpark.SetActive(true);
        break;
      case 14:
        _playerText.SetProps(new("It's sending me some text in binary format. If only I can find a way to <mark=#ffff00aa> translate binary into text  </mark>..."));
        _aiText.SetProps(new(""));
        _playerBubble.SetActive(true);
        _aiSpark.SetActive(false);
        break;
      case 15:
        _playerText.SetProps(new(""));
        _aiText.SetProps(new("Correct. You may proceed."));
        _playerBubble.SetActive(false);
        _aiSpark.SetActive(true);
        break;
      case 16:
        _playerText.SetProps(new("Woot! ^O^"));
        _aiText.SetProps(new(""));
        _playerBubble.SetActive(true);
        _aiSpark.SetActive(false);
        break;
      default:
        _button.gameObject.SetActive(false);
        break;
    }

    DOTween.Sequence()
      .AppendInterval(0.5f)
      .AppendCallback(() => _button.SetProps(new()
      {
        OnClick = OnButtonClick
      }));
  }

  void OnButtonClick() => _contexts.gameEvent.CreateEntity().AddTutorialNextEvent(_entity.tutorial.Step);
}