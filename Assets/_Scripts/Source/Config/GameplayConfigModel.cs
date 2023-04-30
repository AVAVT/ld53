using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GameplayConfigModel", menuName = "Databases/GameplayConfigModel")]
public class GameplayConfigModel : ScriptableObject
{
  public float TurnTime = 0.5f;
  public int ImportInterval = 100;
  public Vector2Int BoardSize = new(27, 17);
  public Vector2Int StorageZone = new(17, 17);
  public List<Vector2Int> IncomingZone;
  public List<Vector2Int> OutgoingZone;

  public List<LevelConfigModel> Levels;
}