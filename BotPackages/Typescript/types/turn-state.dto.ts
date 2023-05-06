export type TurnState = {
  mapWidth: number; // width of the map
  mapHeight: number; // height of the map
  tiles: TileInfo[]; // array of all tiles on the map
  turn: number; // current turn number
  drones: DroneState[]; // array of all drones' state
  packages: PackageState[]; // array of all packages' state
  expectedDeliveries: ExpectedDelivery[]; // array of delivery locations that must be filled before the next delivery
  nextIncomingAt: number; // at which turn the next set of package will come
  nextDeliveryAt: number; // at which turn the current expectedDeliveries should be completed
};

export type TileInfo = {
  x: number; // x coordinate of the tile
  y: number; // y coordinate of the tile
  droppable: boolean; // is this a storage spot (is drone allowed to drop a package here)
};

export type DroneState = {
  id: number; // id of the drone (globally unique)
  x: number; // x coordinate of the drone
  y: number; // y coordinate of the drone
  holding: number | null; // id of the package this drone is holding. null if drone is not holding anything
};

export type PackageState = {
  id: number; // id of the package (globally unique)
  x: number; // x coordinate of the package
  y: number; // x coordinate of the package
  type: PackageType; // type of the package
  heldBy: number | null; // id of the drone currently holding this package. null if package is not being carried
};

export type ExpectedDelivery = {
  x: number; // x coordinate of the drop spot
  y: number; // y coordinate of the drop spot
  type: PackageType; // type of the package expected in this spot
};

export enum PackageType {
  Red = 0,
  Green = 1,
  Blue = 2,
  Purple = 3,
}
