//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class MenuIndexEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IMenuIndexListener> _listenerBuffer;

    public MenuIndexEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IMenuIndexListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.MenuIndex)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasMenuIndex && entity.hasMenuIndexListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.menuIndex;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.menuIndexListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnMenuIndex(e, component.Value);
            }
        }
    }
}