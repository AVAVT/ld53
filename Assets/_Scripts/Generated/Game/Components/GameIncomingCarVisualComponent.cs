//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly IncomingCarVisualComponent incomingCarVisualComponent = new IncomingCarVisualComponent();

    public bool isIncomingCarVisual {
        get { return HasComponent(GameComponentsLookup.IncomingCarVisual); }
        set {
            if (value != isIncomingCarVisual) {
                var index = GameComponentsLookup.IncomingCarVisual;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : incomingCarVisualComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherIncomingCarVisual;

    public static Entitas.IMatcher<GameEntity> IncomingCarVisual {
        get {
            if (_matcherIncomingCarVisual == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.IncomingCarVisual);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherIncomingCarVisual = matcher;
            }

            return _matcherIncomingCarVisual;
        }
    }
}
