using System;

[Flags]
public enum SceneTag
{
  MainMenu = 1 << 0,
  Gameplay = 1 << 1,
  LevelTitle = 1 << 2,
  All = ~0
}