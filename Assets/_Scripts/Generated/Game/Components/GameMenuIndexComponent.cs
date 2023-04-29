//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MenuIndexComponent menuIndex { get { return (MenuIndexComponent)GetComponent(GameComponentsLookup.MenuIndex); } }
    public bool hasMenuIndex { get { return HasComponent(GameComponentsLookup.MenuIndex); } }

    public void AddMenuIndex(int newValue) {
        var index = GameComponentsLookup.MenuIndex;
        var component = (MenuIndexComponent)CreateComponent(index, typeof(MenuIndexComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMenuIndex(int newValue) {
        var index = GameComponentsLookup.MenuIndex;
        var component = (MenuIndexComponent)CreateComponent(index, typeof(MenuIndexComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMenuIndex() {
        RemoveComponent(GameComponentsLookup.MenuIndex);
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

    static Entitas.IMatcher<GameEntity> _matcherMenuIndex;

    public static Entitas.IMatcher<GameEntity> MenuIndex {
        get {
            if (_matcherMenuIndex == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MenuIndex);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMenuIndex = matcher;
            }

            return _matcherMenuIndex;
        }
    }
}