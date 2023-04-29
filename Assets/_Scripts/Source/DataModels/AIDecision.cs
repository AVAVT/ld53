using System;
using Newtonsoft.Json;

[Serializable]
public class AIDecision
{
  public int Id { get; init; }
  public Move Movement { get; init; }
  public bool PickDrop { get; init; }

  [JsonConstructor]
  public AIDecision(int id, Move movement, bool pickDrop = false)
  {
    Id = id;
    Movement = movement;
    PickDrop = pickDrop;
  }
}