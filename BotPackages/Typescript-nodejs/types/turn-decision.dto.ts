export type TurnDecision = {
  droneDecisions: DroneDecision[]; // array of commands given to drones
};

export type DroneDecision = {
  id: number; // id of the drone you're giving command to
  move: Move; // action the drone should take
};

export enum Move {
  PickOrDrop = 0,
  Up = 1,
  Right = 2,
  Down = 3,
  Left = 4,
}
