using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OutgoingCarView : GameBaseController, IEventListener, IAnyOutgoingCarListener, IAnyOutgoingCarRemovedListener
{

  public void RegisterListeners(Contexts contexts, GameEntity entity)
  {
    gameObject.SetActive(false);
    entity.AddAnyOutgoingCarListener(this);
    entity.AddAnyOutgoingCarRemovedListener(this);
  }

  protected override void UnbindEntity()
  {
    _entity.RemoveAnyOutgoingCarListener(this);
    _entity.RemoveAnyOutgoingCarRemovedListener(this);
    base.UnbindEntity();
  }

  public void OnAnyIncomingCar(GameEntity entity, List<PackageType> packages)
  {
  }
  public void OnAnyIncomingCarRemoved(GameEntity entity)
  {
  }
  public void OnAnyOutgoingCar(GameEntity entity, List<PackageType> expects)
  {
    gameObject.SetActive(true);
    transform.DOKill();
    transform.DOMove(new Vector3(14 * 60, 0, 0), _contexts.config.gameplayConfig.Value.TurnTime * 3).From(new Vector3(1920, 0, 0)).SetEase(Ease.OutCubic);
  }
  public void OnAnyOutgoingCarRemoved(GameEntity entity)
  {
    transform.DOKill();
    transform.DOMove(new Vector3(1920, 0, 0), _contexts.config.gameplayConfig.Value.TurnTime * 3).SetEase(Ease.InCubic).OnComplete(() => gameObject.SetActive(false));
  }
}