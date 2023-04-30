import { TurnStateDto } from "../types/turn-state.dto";
import { Move, TurnDecision } from "../types/turn-decision.dto";
import simpleBot from "../example-bots/simple-bot";

export default function doTurn(turnState: TurnStateDto): TurnDecision {
  // return simpleBot.doTurn(turnState);

  return {
    droneDecisions: turnState.drones.map((drone, index) => ({
      id: drone.id,
      move:
        drone.holding == null &&
        turnState.packages.some((pkg) => pkg.x == drone.x && pkg.y == drone.y)
          ? Move.PickOrDrop
          : ((Math.floor(Math.random() * 4) + 1) as Move),
    })),
  };
}
