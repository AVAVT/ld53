using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config, Unique]
public class MainMenuConfigComponent : IComponent
{
  public MainMenuConfigModel Value;
}