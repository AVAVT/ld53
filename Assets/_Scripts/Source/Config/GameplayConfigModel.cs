using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayConfigModel", menuName = "Databases/GameplayConfigModel")]
public class GameplayConfigModel : ScriptableObject
{
  public float TurnTime = 0.5f;
  public int DeliveryInterval = 40;
  public Vector2Int BoardSize = new(27, 17);
  public Vector2Int StorageZone = new(17, 17);
  public List<Vector2Int> IncomingZone;
  public List<Vector2Int> OutcomingZone;

  public List<LevelConfigModel> Levels;
}