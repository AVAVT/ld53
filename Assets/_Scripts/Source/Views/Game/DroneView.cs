using DevDef.Views;

namespace System.Runtime.CompilerServices.Views.Game
{
  public class DroneView : GameBaseController
  {
    void Update()
    {
      if (!_entity.hasPosition) return;
      transform.position = _entity.position.Value;
    }
  }
}