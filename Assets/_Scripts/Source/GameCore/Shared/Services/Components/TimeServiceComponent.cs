using Entitas;
using Entitas.CodeGeneration.Attributes;

[Service, Unique]
public class TimeServiceComponent : IComponent
{
  public ITimeService Instance;
}