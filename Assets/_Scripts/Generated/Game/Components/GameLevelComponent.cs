//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity levelEntity { get { return GetGroup(GameMatcher.Level).GetSingleEntity(); } }
    public LevelComponent level { get { return levelEntity.level; } }
    public bool hasLevel { get { return levelEntity != null; } }

    public GameEntity SetLevel(int newValue) {
        if (hasLevel) {
            throw new Entitas.EntitasException("Could not set Level!\n" + this + " already has an entity with LevelComponent!",
                "You should check if the context already has a levelEntity before setting it or use context.ReplaceLevel().");
        }
        var entity = CreateEntity();
        entity.AddLevel(newValue);
        return entity;
    }

    public void ReplaceLevel(int newValue) {
        var entity = levelEntity;
        if (entity == null) {
            entity = SetLevel(newValue);
        } else {
            entity.ReplaceLevel(newValue);
        }
    }

    public void RemoveLevel() {
        levelEntity.Destroy();
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

    public LevelComponent level { get { return (LevelComponent)GetComponent(GameComponentsLookup.Level); } }
    public bool hasLevel { get { return HasComponent(GameComponentsLookup.Level); } }

    public void AddLevel(int newValue) {
        var index = GameComponentsLookup.Level;
        var component = (LevelComponent)CreateComponent(index, typeof(LevelComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLevel(int newValue) {
        var index = GameComponentsLookup.Level;
        var component = (LevelComponent)CreateComponent(index, typeof(LevelComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLevel() {
        RemoveComponent(GameComponentsLookup.Level);
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

    static Entitas.IMatcher<GameEntity> _matcherLevel;

    public static Entitas.IMatcher<GameEntity> Level {
        get {
            if (_matcherLevel == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Level);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevel = matcher;
            }

            return _matcherLevel;
        }
    }
}
