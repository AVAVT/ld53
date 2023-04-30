//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity levelTitleEntity { get { return GetGroup(GameMatcher.LevelTitle).GetSingleEntity(); } }

    public bool isLevelTitle {
        get { return levelTitleEntity != null; }
        set {
            var entity = levelTitleEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isLevelTitle = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly LevelTitleComponent levelTitleComponent = new LevelTitleComponent();

    public bool isLevelTitle {
        get { return HasComponent(GameComponentsLookup.LevelTitle); }
        set {
            if (value != isLevelTitle) {
                var index = GameComponentsLookup.LevelTitle;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : levelTitleComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherLevelTitle;

    public static Entitas.IMatcher<GameEntity> LevelTitle {
        get {
            if (_matcherLevelTitle == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelTitle);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelTitle = matcher;
            }

            return _matcherLevelTitle;
        }
    }
}
