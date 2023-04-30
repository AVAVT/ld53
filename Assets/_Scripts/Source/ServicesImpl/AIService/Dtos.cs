public struct CaptchaDto
{
  public string question { get; init; }
}

public struct CaptchaAnswer
{
  public string answer { get; init; }
}

public struct TurnStateDto
{
  public int mapWidth { get; init; }
  public int mapHeight { get; init; }
  public int turn { get; init; }
  public TileInfoDto[] tiles { get; init; }
  public DroneStateDto[] drones { get; init; }
  public PackageStateDto[] packages { get; init; }
  public ExpectedDeliveryDto[] expectedDeliveries { get; init; }
}

public struct ExpectedDeliveryDto
{
  public int x { get; init; }
  public int y { get; init; }
  public PackageType type { get; init; }
}

public class TileInfoDto
{
  public int x { get; init; }
  public int y { get; init; }
  public bool droppable { get; init; }
}

public struct DroneStateDto
{
  public int x { get; init; }
  public int y { get; init; }
  public int id { get; init; }
  public int? holding { get; init; }
}

public struct PackageStateDto
{
  public int x { get; init; }
  public int y { get; init; }
  public int id { get; init; }
  public PackageType type { get; init; }
  public int? heldBy { get; init; }
}

public struct TurnDecision
{
  public DroneDecision[] droneDecisions { get; init; }
}

public struct DroneDecision
{
  public int id { get; init; }
  public Move move { get; init; }
}