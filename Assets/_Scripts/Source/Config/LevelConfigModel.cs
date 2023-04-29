using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfigModel", menuName = "Databases/LevelConfigModel")]
public class LevelConfigModel : ScriptableObject
{
  public int Red;
  public int Green;
  public int Blue;
  public int Purple;
  public int ItemPerWave;
}