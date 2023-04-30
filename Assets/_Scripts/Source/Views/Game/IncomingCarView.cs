using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IncomingCarView : GameBaseController, IEventListener, IAnyIncomingCarListener, IAnyIncomingCarRemovedListener
{

  public void RegisterListeners(Contexts contexts, GameEntity entity)
  {
    gameObject.SetActive(false);
    entity.AddAnyIncomingCarListener(this);
    entity.AddAnyIncomingCarRemovedListener(this);
  }

  protected override void UnbindEntity()
  {
    _entity.RemoveAnyIncomingCarListener(this);
    _entity.RemoveAnyIncomingCarRemovedListener(this);
    base.UnbindEntity();
  }

  public void OnAnyIncomingCar(GameEntity entity, List<PackageType> packages)
  {
    gameObject.SetActive(true);
    transform.DOKill();
    transform.DOMove(new Vector3(-11 * 60, -3 * 60, 0), _contexts.config.gameplayConfig.Value.TurnTime * 3 - 0.3f).From(new Vector3(-11 * 60, 540, 0)).SetEase(Ease.OutCubic);
  }
  public void OnAnyIncomingCarRemoved(GameEntity entity)
  {
    transform.DOKill();
    transform.DOMove(new Vector3(-11 * 60, -1080, 0), _contexts.config.gameplayConfig.Value.TurnTime * 3).SetDelay(0.2f).SetEase(Ease.InCubic).OnComplete(() => gameObject.SetActive(false));
  }
}