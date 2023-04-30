//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameEventSystems : Feature {

    public GameEventSystems(Contexts contexts) {
        Add(new DisabledEventSystem(contexts)); // priority: 0
        Add(new DisabledRemovedEventSystem(contexts)); // priority: 0
        Add(new EndingEventSystem(contexts)); // priority: 0
        Add(new AnyIncomingCarEventSystem(contexts)); // priority: 0
        Add(new AnyIncomingCarRemovedEventSystem(contexts)); // priority: 0
        Add(new MainMenuEventSystem(contexts)); // priority: 0
        Add(new MenuIndexEventSystem(contexts)); // priority: 0
        Add(new MenuSizeEventSystem(contexts)); // priority: 0
        Add(new AnyOutgoingCarEventSystem(contexts)); // priority: 0
        Add(new AnyOutgoingCarRemovedEventSystem(contexts)); // priority: 0
        Add(new AnyPauseEventSystem(contexts)); // priority: 0
        Add(new AnyPauseRemovedEventSystem(contexts)); // priority: 0
        Add(new PositionEventSystem(contexts)); // priority: 0
        Add(new SuspicionEventSystem(contexts)); // priority: 0
        Add(new AnyTurnEventSystem(contexts)); // priority: 0
        Add(new TutorialEventSystem(contexts)); // priority: 0
    }
}
