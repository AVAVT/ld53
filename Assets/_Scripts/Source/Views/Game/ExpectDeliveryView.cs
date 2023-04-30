using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ExpectDeliveryView : GameBaseController, IEventListener, IPositionListener
{
  [SerializeField] Color[] _colors;

  public override void InitializeView(Contexts contexts, GameEntity entity)
  {
    base.InitializeView(contexts, entity);
    GetComponent<SpriteRenderer>().color = _colors[(int)entity.expectedDelivery.Type].WithA(0.3f);
    transform.position = Vector3.one * 9999;
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
  }
}