using UnityEngine;

public sealed class MainMenuView : GameUIViewController
{
  [SerializeField] ButtonTextComponent _startButton;
  public override UILayer Layer => UILayer.Foreground;

  public override void InitializeView(Contexts contexts, GameEntity entity)
  {
    base.InitializeView(contexts, entity);
    _startButton.SetProps(
      new ButtonTextComponentProps
      {
        OnClick = () => contexts.gameEvent.CreateEntity().isEventStartGame = true,
        Text = "Start Game"
      }
    );
  }
}