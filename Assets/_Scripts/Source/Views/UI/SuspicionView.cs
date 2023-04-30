using System.Collections;
using UnityEngine;

public class SuspicionView : GameUIViewController, IEventListener, ISuspicionListener
{
  [SerializeField] RectTransform _root;
  [SerializeField] RectTransform _bar;
  [SerializeField] TextComponent _text;

  public override UILayer Layer => UILayer.Foreground;

  public void RegisterListeners(Contexts contexts, GameEntity entity)
  {
    if (entity.hasSuspicion) OnSuspicion(entity, entity.suspicion.Value);
    entity.AddSuspicionListener(this);
  }

  protected override void UnbindEntity()
  {
    _entity.RemoveSuspicionListener(this);
    base.UnbindEntity();
  }

  public void OnSuspicion(GameEntity entity, int value)
  {
    _bar.sizeDelta = _bar.sizeDelta.WithX((_root.sizeDelta.x - 4) * value / 100f);
    _text.SetProps(new($"Suspicion: {value}%"));
  }
}