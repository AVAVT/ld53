//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyOutgoingCarListenerComponent anyOutgoingCarListener { get { return (AnyOutgoingCarListenerComponent)GetComponent(GameComponentsLookup.AnyOutgoingCarListener); } }
    public bool hasAnyOutgoingCarListener { get { return HasComponent(GameComponentsLookup.AnyOutgoingCarListener); } }

    public void AddAnyOutgoingCarListener(System.Collections.Generic.List<IAnyOutgoingCarListener> newValue) {
        var index = GameComponentsLookup.AnyOutgoingCarListener;
        var component = (AnyOutgoingCarListenerComponent)CreateComponent(index, typeof(AnyOutgoingCarListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyOutgoingCarListener(System.Collections.Generic.List<IAnyOutgoingCarListener> newValue) {
        var index = GameComponentsLookup.AnyOutgoingCarListener;
        var component = (AnyOutgoingCarListenerComponent)CreateComponent(index, typeof(AnyOutgoingCarListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyOutgoingCarListener() {
        RemoveComponent(GameComponentsLookup.AnyOutgoingCarListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAnyOutgoingCarListener;

    public static Entitas.IMatcher<GameEntity> AnyOutgoingCarListener {
        get {
            if (_matcherAnyOutgoingCarListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyOutgoingCarListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyOutgoingCarListener = matcher;
            }

            return _matcherAnyOutgoingCarListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddAnyOutgoingCarListener(IAnyOutgoingCarListener value) {
        var listeners = hasAnyOutgoingCarListener
            ? anyOutgoingCarListener.value
            : new System.Collections.Generic.List<IAnyOutgoingCarListener>();
        listeners.Add(value);
        ReplaceAnyOutgoingCarListener(listeners);
    }

    public void RemoveAnyOutgoingCarListener(IAnyOutgoingCarListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyOutgoingCarListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyOutgoingCarListener();
        } else {
            ReplaceAnyOutgoingCarListener(listeners);
        }
    }
}
