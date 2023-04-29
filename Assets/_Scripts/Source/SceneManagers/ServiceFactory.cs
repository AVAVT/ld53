using DevDef.Services;
using Entitas;
using UnityEngine;

namespace DevDef.SceneManagers
{
  public class ServiceFactory : MonoBehaviour
  {
    Contexts _contexts;
    ViewService _viewService;

    public void SetupServices(Contexts contexts, RootGameManager rootGameManager)
    {
      _contexts = contexts;

      var serviceContext = contexts.service;

      serviceContext.SetGameManagerService(rootGameManager);

      serviceContext.SetLoggingService(new UnityEditorLoggingService());

      serviceContext.SetTimeService(GetComponent<TimeService>() ?? gameObject.AddComponent<TimeService>());

      _viewService = FindObjectOfType<ViewService>();
      _viewService.Initialize(contexts);
      serviceContext.SetViewService(_viewService);

      contexts.game.OnEntityCreated += AddGameEntityId;
      contexts.game.OnEntityCreated += AddViewServiceBindings;

      serviceContext.SetAIService(new RemoteAiService(contexts));
    }

    void OnDestroy()
    {
      _contexts.game.OnEntityCreated -= AddGameEntityId;
      _contexts.game.OnEntityCreated -= AddViewServiceBindings;
    }

    static void AddGameEntityId(IContext context, IEntity entity)
    {
      (entity as GameEntity)!.AddEntityId(entity.creationIndex);
    }

    void AddViewServiceBindings(IContext context, IEntity entity)
    {
      (entity as GameEntity)!.OnComponentAdded += _viewService.AddViewForEntityIfNeeded;
    }
  }
}