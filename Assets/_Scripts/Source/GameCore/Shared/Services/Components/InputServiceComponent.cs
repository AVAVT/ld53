using Entitas;
using Entitas.CodeGeneration.Attributes;

[Service, Unique]
public class InputServiceComponent : IComponent
{
  public IInputService Instance;
}