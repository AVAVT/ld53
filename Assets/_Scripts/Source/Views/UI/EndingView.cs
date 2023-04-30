using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class EndingView : GameUIViewController, IEventListener, IEndingListener
{
  public override UILayer Layer => UILayer.Foreground;

  [SerializeField] GameObject _endingImg;
  [SerializeField] TextComponent _dialogue;
  [SerializeField] GameObject _endingReddit;
  [SerializeField] GameObject _endingCursor;
  [SerializeField] TMP_Text _thanks;
  [SerializeField] TMP_Text _thanks2;
  [SerializeField] VideoPlayer _video;
  [SerializeField] ButtonTextComponent _button;

  public void RegisterListeners(Contexts contexts, GameEntity entity)
  {
    if (entity.hasEnding) OnEnding(entity, entity.ending.Step);
    entity.AddEndingListener(this);
  }

  protected override void UnbindEntity()
  {
    _entity.RemoveEndingListener(this);
    base.UnbindEntity();
  }

  public void OnEnding(GameEntity entity, int step)
  {
    _button.SetProps(new() { OnClick = null });
    _endingImg.gameObject.SetActive(step < 2);
    _endingReddit.gameObject.SetActive(step is >= 2 and < 4);
    _video.gameObject.SetActive(step >= 4);

    switch (step) {
      case 0:
        _dialogue.SetProps(new("Finally I have found the first DragonByte!"));
        break;
      case 1:
        _dialogue.SetProps(new("It should guide me toward mastering the next discipline.\nLet's see here..."));
        break;
      case 3:
        _endingCursor.SetActive(true);
        break;
      case 4:
        _video.targetCamera = Camera.main;
        _video.Play();
        _button.gameObject.SetActive(false);
        _thanks.DOColor(_thanks.color.WithA(1), 0.5f).SetDelay(3f).OnComplete(() => _thanks2.color = _thanks2.color.WithA(1));
        break;
    }

    DOTween.Sequence()
      .AppendInterval(0.5f)
      .AppendCallback(() => _button.SetProps(new()
      {
        OnClick = OnButtonClick
      }));
  }

  void OnButtonClick() => _contexts.gameEvent.CreateEntity().AddEndingNextEvent(_entity.ending.Step);
}