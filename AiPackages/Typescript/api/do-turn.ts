import { json } from "stream/consumers";
import { TurnStateDto } from "../types/turn-state.dto";
import { Move, TurnDecision } from "../types/turn-decision.dto";

export default async function doTurn(
  turnState: TurnStateDto
): Promise<TurnDecision> {
  console.log(turnState);
  return {
    droneDecisions: turnState.drones.map((drone) => ({
      id: drone.id,
      move:
        drone.holding == null &&
        turnState.packages.some((pkg) => pkg.x == drone.x && pkg.y == drone.y)
          ? Move.PickOrDrop
          : drone.id == 429
          ? Move.Right
          : Move.Down,
    })),
  };
}
