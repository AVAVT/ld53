//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ServiceContext {

    public ServiceEntity gameManagerServiceEntity { get { return GetGroup(ServiceMatcher.GameManagerService).GetSingleEntity(); } }
    public GameManagerServiceComponent gameManagerService { get { return gameManagerServiceEntity.gameManagerService; } }
    public bool hasGameManagerService { get { return gameManagerServiceEntity != null; } }

    public ServiceEntity SetGameManagerService(IGameManagerService newInstance) {
        if (hasGameManagerService) {
            throw new Entitas.EntitasException("Could not set GameManagerService!\n" + this + " already has an entity with GameManagerServiceComponent!",
                "You should check if the context already has a gameManagerServiceEntity before setting it or use context.ReplaceGameManagerService().");
        }
        var entity = CreateEntity();
        entity.AddGameManagerService(newInstance);
        return entity;
    }

    public void ReplaceGameManagerService(IGameManagerService newInstance) {
        var entity = gameManagerServiceEntity;
        if (entity == null) {
            entity = SetGameManagerService(newInstance);
        } else {
            entity.ReplaceGameManagerService(newInstance);
        }
    }

    public void RemoveGameManagerService() {
        gameManagerServiceEntity.Destroy();
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
public partial class ServiceEntity {

    public GameManagerServiceComponent gameManagerService { get { return (GameManagerServiceComponent)GetComponent(ServiceComponentsLookup.GameManagerService); } }
    public bool hasGameManagerService { get { return HasComponent(ServiceComponentsLookup.GameManagerService); } }

    public void AddGameManagerService(IGameManagerService newInstance) {
        var index = ServiceComponentsLookup.GameManagerService;
        var component = (GameManagerServiceComponent)CreateComponent(index, typeof(GameManagerServiceComponent));
        component.Instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceGameManagerService(IGameManagerService newInstance) {
        var index = ServiceComponentsLookup.GameManagerService;
        var component = (GameManagerServiceComponent)CreateComponent(index, typeof(GameManagerServiceComponent));
        component.Instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveGameManagerService() {
        RemoveComponent(ServiceComponentsLookup.GameManagerService);
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
public sealed partial class ServiceMatcher {

    static Entitas.IMatcher<ServiceEntity> _matcherGameManagerService;

    public static Entitas.IMatcher<ServiceEntity> GameManagerService {
        get {
            if (_matcherGameManagerService == null) {
                var matcher = (Entitas.Matcher<ServiceEntity>)Entitas.Matcher<ServiceEntity>.AllOf(ServiceComponentsLookup.GameManagerService);
                matcher.componentNames = ServiceComponentsLookup.componentNames;
                _matcherGameManagerService = matcher;
            }

            return _matcherGameManagerService;
        }
    }
}
