import { TurnStateDto } from "../types/turn-state.dto";
import { Move, TurnDecision } from "../types/turn-decision.dto";

export default async function doTurn(
  turnState: TurnStateDto
): Promise<TurnDecision> {
  console.log("=======");
  console.log(turnState);
  const result = {
    droneDecisions: turnState.drones.map((drone, index) => ({
      id: drone.id,
      move:
        drone.holding == null &&
        turnState.packages.some((pkg) => pkg.x == drone.x && pkg.y == drone.y)
          ? Move.PickOrDrop
          : ((Math.floor(Math.random() * 4) + 1) as Move),
    })),
  };

  console.log(result);
  return result;
}
