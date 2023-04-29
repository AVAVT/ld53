using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace DevDef.Views
{
  public abstract class GameBaseController : MonoBehaviour, IViewController
  {
    protected Contexts _contexts;
    protected GameEntity _entity;

    public virtual void InitializeView(Contexts contexts, GameEntity entity)
    {
      gameObject.Link(entity);
      entity.OnDestroyEntity += OnDestroyEntity;
      _contexts = contexts;
      _entity = entity;
    }

    protected void OnDestroy()
    {
      try {
        gameObject.Unlink();
        if (_entity.GetComponents().Length > 0) UnbindEntity();
      }
      catch {
        // ignored
      }
    }

    protected virtual void UnbindEntity()
    {
      _entity.OnDestroyEntity -= OnDestroyEntity;
      if (_entity.hasView) _entity.RemoveView();
    }

    protected virtual void OnDestroyEntity(IEntity entity)
    {
      GameObject o;
      (o = gameObject).Unlink();
      Destroy(o);
    }
  }
}