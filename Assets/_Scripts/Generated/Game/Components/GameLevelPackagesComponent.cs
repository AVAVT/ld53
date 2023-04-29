//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity levelPackagesEntity { get { return GetGroup(GameMatcher.LevelPackages).GetSingleEntity(); } }
    public LevelPackagesComponent levelPackages { get { return levelPackagesEntity.levelPackages; } }
    public bool hasLevelPackages { get { return levelPackagesEntity != null; } }

    public GameEntity SetLevelPackages(System.Collections.Generic.List<PackageType> newPackages, int newAmountPerIncoming) {
        if (hasLevelPackages) {
            throw new Entitas.EntitasException("Could not set LevelPackages!\n" + this + " already has an entity with LevelPackagesComponent!",
                "You should check if the context already has a levelPackagesEntity before setting it or use context.ReplaceLevelPackages().");
        }
        var entity = CreateEntity();
        entity.AddLevelPackages(newPackages, newAmountPerIncoming);
        return entity;
    }

    public void ReplaceLevelPackages(System.Collections.Generic.List<PackageType> newPackages, int newAmountPerIncoming) {
        var entity = levelPackagesEntity;
        if (entity == null) {
            entity = SetLevelPackages(newPackages, newAmountPerIncoming);
        } else {
            entity.ReplaceLevelPackages(newPackages, newAmountPerIncoming);
        }
    }

    public void RemoveLevelPackages() {
        levelPackagesEntity.Destroy();
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

    public LevelPackagesComponent levelPackages { get { return (LevelPackagesComponent)GetComponent(GameComponentsLookup.LevelPackages); } }
    public bool hasLevelPackages { get { return HasComponent(GameComponentsLookup.LevelPackages); } }

    public void AddLevelPackages(System.Collections.Generic.List<PackageType> newPackages, int newAmountPerIncoming) {
        var index = GameComponentsLookup.LevelPackages;
        var component = (LevelPackagesComponent)CreateComponent(index, typeof(LevelPackagesComponent));
        component.Packages = newPackages;
        component.AmountPerIncoming = newAmountPerIncoming;
        AddComponent(index, component);
    }

    public void ReplaceLevelPackages(System.Collections.Generic.List<PackageType> newPackages, int newAmountPerIncoming) {
        var index = GameComponentsLookup.LevelPackages;
        var component = (LevelPackagesComponent)CreateComponent(index, typeof(LevelPackagesComponent));
        component.Packages = newPackages;
        component.AmountPerIncoming = newAmountPerIncoming;
        ReplaceComponent(index, component);
    }

    public void RemoveLevelPackages() {
        RemoveComponent(GameComponentsLookup.LevelPackages);
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

    static Entitas.IMatcher<GameEntity> _matcherLevelPackages;

    public static Entitas.IMatcher<GameEntity> LevelPackages {
        get {
            if (_matcherLevelPackages == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelPackages);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelPackages = matcher;
            }

            return _matcherLevelPackages;
        }
    }
}
