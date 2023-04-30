using UnityEngine;

public abstract class GameUIViewController : GameBaseController
{
  public abstract UILayer Layer { get; }
  protected RectTransform _rectTransform;
  public override void InitializeView(Contexts contexts, GameEntity entity)
  {
    base.InitializeView(contexts, entity);

    _rectTransform = transform as RectTransform;
  }
}