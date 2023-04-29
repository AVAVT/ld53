//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity incomingCarEntity { get { return GetGroup(GameMatcher.IncomingCar).GetSingleEntity(); } }
    public IncomingCarComponent incomingCar { get { return incomingCarEntity.incomingCar; } }
    public bool hasIncomingCar { get { return incomingCarEntity != null; } }

    public GameEntity SetIncomingCar(System.Collections.Generic.List<PackageType> newPackages) {
        if (hasIncomingCar) {
            throw new Entitas.EntitasException("Could not set IncomingCar!\n" + this + " already has an entity with IncomingCarComponent!",
                "You should check if the context already has a incomingCarEntity before setting it or use context.ReplaceIncomingCar().");
        }
        var entity = CreateEntity();
        entity.AddIncomingCar(newPackages);
        return entity;
    }

    public void ReplaceIncomingCar(System.Collections.Generic.List<PackageType> newPackages) {
        var entity = incomingCarEntity;
        if (entity == null) {
            entity = SetIncomingCar(newPackages);
        } else {
            entity.ReplaceIncomingCar(newPackages);
        }
    }

    public void RemoveIncomingCar() {
        incomingCarEntity.Destroy();
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

    public IncomingCarComponent incomingCar { get { return (IncomingCarComponent)GetComponent(GameComponentsLookup.IncomingCar); } }
    public bool hasIncomingCar { get { return HasComponent(GameComponentsLookup.IncomingCar); } }

    public void AddIncomingCar(System.Collections.Generic.List<PackageType> newPackages) {
        var index = GameComponentsLookup.IncomingCar;
        var component = (IncomingCarComponent)CreateComponent(index, typeof(IncomingCarComponent));
        component.Packages = newPackages;
        AddComponent(index, component);
    }

    public void ReplaceIncomingCar(System.Collections.Generic.List<PackageType> newPackages) {
        var index = GameComponentsLookup.IncomingCar;
        var component = (IncomingCarComponent)CreateComponent(index, typeof(IncomingCarComponent));
        component.Packages = newPackages;
        ReplaceComponent(index, component);
    }

    public void RemoveIncomingCar() {
        RemoveComponent(GameComponentsLookup.IncomingCar);
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

    static Entitas.IMatcher<GameEntity> _matcherIncomingCar;

    public static Entitas.IMatcher<GameEntity> IncomingCar {
        get {
            if (_matcherIncomingCar == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.IncomingCar);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherIncomingCar = matcher;
            }

            return _matcherIncomingCar;
        }
    }
}
