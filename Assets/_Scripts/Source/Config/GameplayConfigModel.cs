using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayConfigModel", menuName = "Databases/GameplayConfigModel")]
public class GameplayConfigModel : ScriptableObject
{
  public float TurnTime = 0.5f;
  public int DeliveryInterval = 40;
  public Vector2Int BoardSize = new(25, 17);
  public Vector2Int StorageZone = new(17, 17);

  public List<LevelConfigModel> Levels;
}