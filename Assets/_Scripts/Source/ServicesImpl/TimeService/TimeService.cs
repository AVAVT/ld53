using UnityEngine;

namespace DevDef.Services
{
  public class TimeService : MonoBehaviour, ITimeService
  {
    public float DeltaTime { get; private set; }

    void Update()
    {
      DeltaTime = Time.deltaTime;
    }
  }
}
