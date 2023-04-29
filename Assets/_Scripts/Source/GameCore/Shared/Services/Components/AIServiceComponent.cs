using Entitas;
using Entitas.CodeGeneration.Attributes;

[Service, Unique]
public class AIServiceComponent : IComponent
{
  public IAiService Instance;
}