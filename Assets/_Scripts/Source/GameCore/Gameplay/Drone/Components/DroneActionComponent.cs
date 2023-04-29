using Entitas;

[Game]
public class DroneActionComponent : IComponent
{
  public DroneAction Value;
}

public enum DroneAction
{
  Fly,
  PickDrop
}