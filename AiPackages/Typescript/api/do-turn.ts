import { TurnStateDto } from "../types/turn-state.dto";
import { Move, TurnDecision } from "../types/turn-decision.dto";
import simpleBot from "../bots/simple-bot";

export default function doTurn(turnState: TurnStateDto): TurnDecision {
  return simpleBot.doTurn(turnState);
}
