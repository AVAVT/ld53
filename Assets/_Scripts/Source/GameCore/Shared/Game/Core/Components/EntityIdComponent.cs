using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class EntityIdComponent : IComponent
{
  [PrimaryEntityIndex] public int Value;
}