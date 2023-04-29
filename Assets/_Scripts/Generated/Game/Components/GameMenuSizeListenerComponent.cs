//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MenuSizeListenerComponent menuSizeListener { get { return (MenuSizeListenerComponent)GetComponent(GameComponentsLookup.MenuSizeListener); } }
    public bool hasMenuSizeListener { get { return HasComponent(GameComponentsLookup.MenuSizeListener); } }

    public void AddMenuSizeListener(System.Collections.Generic.List<IMenuSizeListener> newValue) {
        var index = GameComponentsLookup.MenuSizeListener;
        var component = (MenuSizeListenerComponent)CreateComponent(index, typeof(MenuSizeListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMenuSizeListener(System.Collections.Generic.List<IMenuSizeListener> newValue) {
        var index = GameComponentsLookup.MenuSizeListener;
        var component = (MenuSizeListenerComponent)CreateComponent(index, typeof(MenuSizeListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMenuSizeListener() {
        RemoveComponent(GameComponentsLookup.MenuSizeListener);
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

    static Entitas.IMatcher<GameEntity> _matcherMenuSizeListener;

    public static Entitas.IMatcher<GameEntity> MenuSizeListener {
        get {
            if (_matcherMenuSizeListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MenuSizeListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMenuSizeListener = matcher;
            }

            return _matcherMenuSizeListener;
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

    public void AddMenuSizeListener(IMenuSizeListener value) {
        var listeners = hasMenuSizeListener
            ? menuSizeListener.value
            : new System.Collections.Generic.List<IMenuSizeListener>();
        listeners.Add(value);
        ReplaceMenuSizeListener(listeners);
    }

    public void RemoveMenuSizeListener(IMenuSizeListener value, bool removeComponentWhenEmpty = true) {
        var listeners = menuSizeListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveMenuSizeListener();
        } else {
            ReplaceMenuSizeListener(listeners);
        }
    }
}
