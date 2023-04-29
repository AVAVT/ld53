//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ViewComponent view { get { return (ViewComponent)GetComponent(GameComponentsLookup.View); } }
    public bool hasView { get { return HasComponent(GameComponentsLookup.View); } }

    public void AddView(IViewController newValue) {
        var index = GameComponentsLookup.View;
        var component = (ViewComponent)CreateComponent(index, typeof(ViewComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceView(IViewController newValue) {
        var index = GameComponentsLookup.View;
        var component = (ViewComponent)CreateComponent(index, typeof(ViewComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveView() {
        RemoveComponent(GameComponentsLookup.View);
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

    static Entitas.IMatcher<GameEntity> _matcherView;

    public static Entitas.IMatcher<GameEntity> View {
        get {
            if (_matcherView == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.View);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherView = matcher;
            }

            return _matcherView;
        }
    }
}
