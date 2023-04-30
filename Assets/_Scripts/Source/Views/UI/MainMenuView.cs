using DG.Tweening;
using TMPro;
using UnityEngine;

public sealed class MainMenuView : GameUIViewController, IEventListener, IMainMenuListener
{
  [SerializeField] ButtonTextComponent _startButton;

  [SerializeField] GameObject _bg1;
  [SerializeField] GameObject _bg2;
  [SerializeField] TMP_Text _title1;
  [SerializeField] TMP_Text _title2;
  [SerializeField] TMP_Text _clickToStart;

  public override UILayer Layer => UILayer.Foreground;

  public override void InitializeView(Contexts contexts, GameEntity entity)
  {
    base.InitializeView(contexts, entity);

    _clickToStart.color = _clickToStart.color.WithA(0);
    _startButton.gameObject.SetActive(false);

    DOTween.Sequence().Append(_title1.DOColor(_title1.color, 0.5f).From(_title1.color.WithA(0)))
      .Insert(0, _title2.DOColor(_title2.color, 1f).From(_title2.color.WithA(0))).AppendCallback(() => {
        _clickToStart.color = _clickToStart.color.WithA(1);
        _startButton.gameObject.SetActive(true);
        _startButton.SetProps(
          new()
          {
            OnClick = () => contexts.gameEvent.CreateEntity().isEventStartGame = true
          }
        );
      });
  }

  public void RegisterListeners(Contexts contexts, GameEntity entity)
  {
    entity.AddMainMenuListener(this);
  }

  protected override void UnbindEntity()
  {
    _entity.RemoveMainMenuListener(this);
    base.UnbindEntity();
  }

  public void OnMainMenu(GameEntity entity, bool started)
  {
    if (!started) return;
    _bg1.SetActive(false);
    _bg2.SetActive(true);
    _startButton.gameObject.SetActive(false);
    _clickToStart.gameObject.SetActive(false);
  }
}