using Entitas.CodeGeneration.Attributes;
using Entitas;

[Config, Unique]
public class GameplayConfigComponent : IComponent
{
  public GameplayConfigModel Value;
}