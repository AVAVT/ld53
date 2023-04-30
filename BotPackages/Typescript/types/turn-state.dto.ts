export type TurnStateDto = {
  mapWidth: number;
  mapHeight: number;
  turn: number;
  drones: DroneStateDto[];
  packages: PackageStateDto[];
  expectedDeliveries: ExpectedDeliveryDto[];
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
  type: PackageType;
  heldBy: number | null;
};

export type ExpectedDeliveryDto = {
  x: number;
  y: number;
  type: PackageType;
};

export enum PackageType {
  Red = 0,
  Green = 1,
  Blue = 2,
  Purple = 3,
  Dragon = 4,
}
