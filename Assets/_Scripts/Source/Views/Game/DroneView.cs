using UnityEngine;

namespace System.Runtime.CompilerServices.Views.Game
{
  public class DroneView : GameBaseController
  {
    public override void InitializeView(Contexts contexts, GameEntity entity)
    {
      base.InitializeView(contexts, entity);
      transform.position = Vector3.one * 9999;
    }

    void Update()
    {
      if (!_entity.hasPosition) return;
      transform.position = _entity.position.Value;
    }
  }
}