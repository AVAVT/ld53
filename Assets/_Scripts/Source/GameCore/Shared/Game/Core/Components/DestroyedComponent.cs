using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Cleanup(CleanupMode.DestroyEntity)]
public class DestroyedComponent : IComponent { }