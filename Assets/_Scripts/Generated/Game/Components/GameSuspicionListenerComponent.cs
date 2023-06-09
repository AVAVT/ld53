//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SuspicionListenerComponent suspicionListener { get { return (SuspicionListenerComponent)GetComponent(GameComponentsLookup.SuspicionListener); } }
    public bool hasSuspicionListener { get { return HasComponent(GameComponentsLookup.SuspicionListener); } }

    public void AddSuspicionListener(System.Collections.Generic.List<ISuspicionListener> newValue) {
        var index = GameComponentsLookup.SuspicionListener;
        var component = (SuspicionListenerComponent)CreateComponent(index, typeof(SuspicionListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSuspicionListener(System.Collections.Generic.List<ISuspicionListener> newValue) {
        var index = GameComponentsLookup.SuspicionListener;
        var component = (SuspicionListenerComponent)CreateComponent(index, typeof(SuspicionListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSuspicionListener() {
        RemoveComponent(GameComponentsLookup.SuspicionListener);
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

    static Entitas.IMatcher<GameEntity> _matcherSuspicionListener;

    public static Entitas.IMatcher<GameEntity> SuspicionListener {
        get {
            if (_matcherSuspicionListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SuspicionListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSuspicionListener = matcher;
            }

            return _matcherSuspicionListener;
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

    public void AddSuspicionListener(ISuspicionListener value) {
        var listeners = hasSuspicionListener
            ? suspicionListener.value
            : new System.Collections.Generic.List<ISuspicionListener>();
        listeners.Add(value);
        ReplaceSuspicionListener(listeners);
    }

    public void RemoveSuspicionListener(ISuspicionListener value, bool removeComponentWhenEmpty = true) {
        var listeners = suspicionListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveSuspicionListener();
        } else {
            ReplaceSuspicionListener(listeners);
        }
    }
}
