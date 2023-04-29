export type TurnStateDto = {
  turn: number;
  drones: DroneStateDto[];
  packages: PackageStateDto[];
};

export type DroneStateDto = {
  id: number;
  x: number;
  y: number;
  holding: number | null;
};

export type PackageStateDto = {
  id: number;
  x: number;
  y: number;
  heldBy: number | null;
};
