using Entitas;
using Entitas.CodeGeneration.Attributes;

[Service, Unique]
public class LoggingServiceComponent : IComponent
{
  public ILoggingService Instance;
}