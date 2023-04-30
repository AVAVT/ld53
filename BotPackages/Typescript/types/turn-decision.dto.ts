export type TurnDecision = {
  droneDecisions: DroneDecision[];
};

export type DroneDecision = {
  id: number;
  move: Move;
};

export enum Move {
  PickOrDrop = 0,
  Up = 1,
  Right = 2,
  Down = 3,
  Left = 4,
}
