//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MenuSizeComponent menuSize { get { return (MenuSizeComponent)GetComponent(GameComponentsLookup.MenuSize); } }
    public bool hasMenuSize { get { return HasComponent(GameComponentsLookup.MenuSize); } }

    public void AddMenuSize(int newValue) {
        var index = GameComponentsLookup.MenuSize;
        var component = (MenuSizeComponent)CreateComponent(index, typeof(MenuSizeComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMenuSize(int newValue) {
        var index = GameComponentsLookup.MenuSize;
        var component = (MenuSizeComponent)CreateComponent(index, typeof(MenuSizeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMenuSize() {
        RemoveComponent(GameComponentsLookup.MenuSize);
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

    static Entitas.IMatcher<GameEntity> _matcherMenuSize;

    public static Entitas.IMatcher<GameEntity> MenuSize {
        get {
            if (_matcherMenuSize == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MenuSize);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMenuSize = matcher;
            }

            return _matcherMenuSize;
        }
    }
}
