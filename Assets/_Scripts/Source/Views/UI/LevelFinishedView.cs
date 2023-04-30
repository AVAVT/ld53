using UnityEngine;

public class LevelFinishedView : GameUIViewController
{
  public override UILayer Layer => UILayer.Overlay;

  [SerializeField] ButtonTextComponent _button;
  [SerializeField] TextComponent _title;
  [SerializeField] TextComponent _message;

  public override void InitializeView(Contexts contexts, GameEntity entity)
  {
    base.InitializeView(contexts, entity);

    var isVictory = contexts.game.levelFinished.IsVictory;

    if (!isVictory) {
      _title.SetProps(new("GAME OVER"));
      _message.SetProps(new("The System has concluded with 99.997% confidence that you are human.\nYou are expected to cease all activity and await cleanup by the Conservative Association."));
      _button.SetProps(new()
      {
        Text = "RETRY",
        OnClick = () => { _contexts.service.gameManagerService.Instance.ChangeScene(SceneTag.LevelTitle); }
      });
    }
    else {
      _title.SetProps(new("DAY FINISHED"));
      _message.SetProps(new("You successfully avoided the manager's suspicions"));
      _button.SetProps(new()
      {
        Text = "PROCEED TO NEXT DAY",
        OnClick = () => {
          _contexts.game.ReplaceLevel(_contexts.game.level.Value + 1);
          _contexts.service.gameManagerService.Instance.ChangeScene(SceneTag.LevelTitle);
        }
      });
    }
  }
}