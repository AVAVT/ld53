using Entitas;
using Entitas.CodeGeneration.Attributes;

[Service, Unique]
public class ViewServiceComponent : IComponent
{
  public IViewService Instance;
}