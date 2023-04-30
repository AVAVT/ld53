using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TileView : GameBaseController
{

  public override void InitializeView(Contexts contexts, GameEntity entity)
  {
    base.InitializeView(contexts, entity);

    transform.position = (Vector2)entity.tile.Position * 60;
    var sr = GetComponent<SpriteRenderer>();
    sr.enabled = entity.tile.Droppable;
  }
}