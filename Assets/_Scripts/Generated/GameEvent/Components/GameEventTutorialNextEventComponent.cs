//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEventEntity {

    public TutorialNextEvent tutorialNextEvent { get { return (TutorialNextEvent)GetComponent(GameEventComponentsLookup.TutorialNextEvent); } }
    public bool hasTutorialNextEvent { get { return HasComponent(GameEventComponentsLookup.TutorialNextEvent); } }

    public void AddTutorialNextEvent(int newStep) {
        var index = GameEventComponentsLookup.TutorialNextEvent;
        var component = (TutorialNextEvent)CreateComponent(index, typeof(TutorialNextEvent));
        component.Step = newStep;
        AddComponent(index, component);
    }

    public void ReplaceTutorialNextEvent(int newStep) {
        var index = GameEventComponentsLookup.TutorialNextEvent;
        var component = (TutorialNextEvent)CreateComponent(index, typeof(TutorialNextEvent));
        component.Step = newStep;
        ReplaceComponent(index, component);
    }

    public void RemoveTutorialNextEvent() {
        RemoveComponent(GameEventComponentsLookup.TutorialNextEvent);
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
public sealed partial class GameEventMatcher {

    static Entitas.IMatcher<GameEventEntity> _matcherTutorialNextEvent;

    public static Entitas.IMatcher<GameEventEntity> TutorialNextEvent {
        get {
            if (_matcherTutorialNextEvent == null) {
                var matcher = (Entitas.Matcher<GameEventEntity>)Entitas.Matcher<GameEventEntity>.AllOf(GameEventComponentsLookup.TutorialNextEvent);
                matcher.componentNames = GameEventComponentsLookup.componentNames;
                _matcherTutorialNextEvent = matcher;
            }

            return _matcherTutorialNextEvent;
        }
    }
}