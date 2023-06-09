//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigContext {

    public ConfigEntity mainMenuConfigEntity { get { return GetGroup(ConfigMatcher.MainMenuConfig).GetSingleEntity(); } }
    public MainMenuConfigComponent mainMenuConfig { get { return mainMenuConfigEntity.mainMenuConfig; } }
    public bool hasMainMenuConfig { get { return mainMenuConfigEntity != null; } }

    public ConfigEntity SetMainMenuConfig(MainMenuConfigModel newValue) {
        if (hasMainMenuConfig) {
            throw new Entitas.EntitasException("Could not set MainMenuConfig!\n" + this + " already has an entity with MainMenuConfigComponent!",
                "You should check if the context already has a mainMenuConfigEntity before setting it or use context.ReplaceMainMenuConfig().");
        }
        var entity = CreateEntity();
        entity.AddMainMenuConfig(newValue);
        return entity;
    }

    public void ReplaceMainMenuConfig(MainMenuConfigModel newValue) {
        var entity = mainMenuConfigEntity;
        if (entity == null) {
            entity = SetMainMenuConfig(newValue);
        } else {
            entity.ReplaceMainMenuConfig(newValue);
        }
    }

    public void RemoveMainMenuConfig() {
        mainMenuConfigEntity.Destroy();
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
public partial class ConfigEntity {

    public MainMenuConfigComponent mainMenuConfig { get { return (MainMenuConfigComponent)GetComponent(ConfigComponentsLookup.MainMenuConfig); } }
    public bool hasMainMenuConfig { get { return HasComponent(ConfigComponentsLookup.MainMenuConfig); } }

    public void AddMainMenuConfig(MainMenuConfigModel newValue) {
        var index = ConfigComponentsLookup.MainMenuConfig;
        var component = (MainMenuConfigComponent)CreateComponent(index, typeof(MainMenuConfigComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMainMenuConfig(MainMenuConfigModel newValue) {
        var index = ConfigComponentsLookup.MainMenuConfig;
        var component = (MainMenuConfigComponent)CreateComponent(index, typeof(MainMenuConfigComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMainMenuConfig() {
        RemoveComponent(ConfigComponentsLookup.MainMenuConfig);
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
public sealed partial class ConfigMatcher {

    static Entitas.IMatcher<ConfigEntity> _matcherMainMenuConfig;

    public static Entitas.IMatcher<ConfigEntity> MainMenuConfig {
        get {
            if (_matcherMainMenuConfig == null) {
                var matcher = (Entitas.Matcher<ConfigEntity>)Entitas.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.MainMenuConfig);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherMainMenuConfig = matcher;
            }

            return _matcherMainMenuConfig;
        }
    }
}
