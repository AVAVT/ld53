using UnityEngine;
using Entitas;

namespace DevDef.SceneManagers
{
  public abstract class BaseSystemRunner : MonoBehaviour
  {
    protected Systems _systems;
    protected static Contexts _contexts;

    protected abstract void Setup();
    protected abstract Systems CreateSystems();

    protected virtual Systems PostCreateSystems(Systems systems) => systems;

    void Start()
    {
      Setup();

      _systems = CreateSystems();
      _systems.Initialize();
    }

    protected virtual void OnDestroy()
    {
      _systems.TearDown();
    }

    void Update()
    {
      _systems.Execute();
    }

    void LateUpdate()
    {
      _systems.Cleanup();
    }

    public void StopAllSystems()
    {
      _systems.DeactivateReactiveSystems();
      _systems.ClearReactiveSystems();
    }
  }
}