using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfigModel", menuName = "Databases/LevelConfigModel")]
public class LevelConfigModel : ScriptableObject
{
  public int Red;
  public int Green;
  public int Blue;
  public int Purple;
  public int ItemPerWave;
  public int DeliveryPerWave;
  public int DeliveryInterval;
  public int FirstDeliveryBuffer;
  [Range(0f, 1f)]
  public float DeliveryRatio;
  public List<Vector2Int> Drones;
  public List<PackageType> PreloadedPackages;
}