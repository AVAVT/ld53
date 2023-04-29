//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyPauseListenerComponent anyPauseListener { get { return (AnyPauseListenerComponent)GetComponent(GameComponentsLookup.AnyPauseListener); } }
    public bool hasAnyPauseListener { get { return HasComponent(GameComponentsLookup.AnyPauseListener); } }

    public void AddAnyPauseListener(System.Collections.Generic.List<IAnyPauseListener> newValue) {
        var index = GameComponentsLookup.AnyPauseListener;
        var component = (AnyPauseListenerComponent)CreateComponent(index, typeof(AnyPauseListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyPauseListener(System.Collections.Generic.List<IAnyPauseListener> newValue) {
        var index = GameComponentsLookup.AnyPauseListener;
        var component = (AnyPauseListenerComponent)CreateComponent(index, typeof(AnyPauseListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyPauseListener() {
        RemoveComponent(GameComponentsLookup.AnyPauseListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyPauseListener;

    public static Entitas.IMatcher<GameEntity> AnyPauseListener {
        get {
            if (_matcherAnyPauseListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyPauseListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyPauseListener = matcher;
            }

            return _matcherAnyPauseListener;
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

    public void AddAnyPauseListener(IAnyPauseListener value) {
        var listeners = hasAnyPauseListener
            ? anyPauseListener.value
            : new System.Collections.Generic.List<IAnyPauseListener>();
        listeners.Add(value);
        ReplaceAnyPauseListener(listeners);
    }

    public void RemoveAnyPauseListener(IAnyPauseListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyPauseListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyPauseListener();
        } else {
            ReplaceAnyPauseListener(listeners);
        }
    }
}