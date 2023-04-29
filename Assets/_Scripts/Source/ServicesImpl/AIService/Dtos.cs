public struct CaptchaDto
{
  public string question { get; init; }
}

public struct TurnStateDto
{
  public int turn { get; init; }
  public DroneStateDto[] drones { get; init; }
  public PackageStateDto[] packages { get; init; }
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