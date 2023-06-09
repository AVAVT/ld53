﻿using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PackageView : GameBaseController
{
  [SerializeField] Color[] _colors;

  public override void InitializeView(Contexts contexts, GameEntity entity)
  {
    base.InitializeView(contexts, entity);
    GetComponent<SpriteRenderer>().color = _colors[(int)entity.package.Type];
    transform.position = Vector3.one * 9999;
  }
  void Update()
  {
    if (!_entity.hasPosition) return;
    transform.position = _entity.position.Value;
  }
}