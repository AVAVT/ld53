using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class TimeComponent : IComponent
{
  public float deltaTime;
  public float timeSinceLevelLoad;
}