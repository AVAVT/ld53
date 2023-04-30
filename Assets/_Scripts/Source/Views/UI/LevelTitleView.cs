using UnityEngine;

public class LevelTitleView : GameUIViewController
{
  public override UILayer Layer => UILayer.Foreground;

  [SerializeField] TextComponent _title;

  public override void InitializeView(Contexts contexts, GameEntity entity)
  {
    base.InitializeView(contexts, entity);
    _title.SetProps(new($"Day {_contexts.game.level.Value + 1}"));
  }
}