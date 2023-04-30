using UnityEngine;

public class ExplosionView : GameBaseController, IEventListener, IPositionListener
{
  public override void InitializeView(Contexts contexts, GameEntity entity)
  {
    base.InitializeView(contexts, entity);
    gameObject.SetActive(false);
  }

  public void DestroyEntity()
  {
    _entity.Destroy();
  }

  public void RegisterListeners(Contexts contexts, GameEntity entity)
  {
    if (entity.hasPosition) OnPosition(entity, entity.position.Value);
    entity.AddPositionListener(this);
  }

  protected override void UnbindEntity()
  {
    _entity.RemovePositionListener(this);
    base.UnbindEntity();
  }

  public void OnPosition(GameEntity entity, Vector2 value)
  {
    transform.position = value;
    gameObject.SetActive(true);
  }
}