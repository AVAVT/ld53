import {
  ExpectedDelivery,
  PackageType,
  TurnState,
} from "../types/turn-state.dto";
import { Move, TurnDecision } from "../types/turn-decision.dto";

export function doTurn(turnState: TurnState): TurnDecision {
  console.log("=======");
  console.log(turnState);
  const result = {
    droneDecisions: turnState.drones.map((drone) => {
      const base = {
        id: drone.id,
      };

      if (drone.holding != null) {
        const holdingPkg = turnState.packages.find(
          (pkg) => pkg.id == drone.holding
        )!;

        var delivery = findTargetDelivery(turnState, holdingPkg.type);

        if (delivery == null)
          return {
            ...base,
            move: Move.PickOrDrop,
          };

        return {
          ...base,
          move: actionTowardTargetLocation(
            drone.x,
            drone.y,
            delivery.x,
            delivery.y
          ),
        };
      } else {
        const delivery = findTargetDelivery(turnState);
        if (delivery == null)
          return {
            ...base,
            move: actionTowardTargetLocation(
              drone.x,
              drone.y,
              -Math.floor(turnState.mapWidth / 2) + 2,
              0
            ),
          };

        const pkg = findPackageForDelivery(turnState, delivery);

        if (pkg == null)
          return {
            ...base,
            move: actionTowardTargetLocation(
              drone.x,
              drone.y,
              -Math.floor(turnState.mapWidth / 2) + 2,
              0
            ),
          };

        return {
          ...base,
          move: actionTowardTargetLocation(drone.x, drone.y, pkg.x, pkg.y),
        };
      }
    }),
  };

  console.log(result);
  return result;
}

function findTargetDelivery(
  turnState: TurnState,
  type: PackageType | null = null
): ExpectedDelivery | null {
  for (const expect of turnState.expectedDeliveries) {
    if (
      turnState.packages.some(
        (p) => p.x == expect.x && p.y == expect.y && p.heldBy == null
      )
    ) {
      continue;
    }

    if (type == null || type == expect.type) return expect;
  }
  return null;
}

function findPackageForDelivery(
  turnState: TurnState,
  delivery: ExpectedDelivery
) {
  for (const pkg of turnState.packages) {
    if (
      turnState.expectedDeliveries.some(
        (expect) => pkg.x == expect.x && pkg.y == expect.y
      )
    ) {
      continue;
    }
    if (pkg.heldBy != null) continue;
    if (pkg.type != delivery.type) continue;
    return pkg;
  }

  return null;
}

function actionTowardTargetLocation(
  xFrom: number,
  yFrom: number,
  xTo: number,
  yTo: number
) {
  var diffX = xTo - xFrom;
  var diffY = yTo - yFrom;

  if (diffX == diffY && diffX == 0) return Move.PickOrDrop;

  if (diffY == 0 || Math.abs(diffX) > Math.abs(diffY)) {
    return diffX < 0 ? Move.Left : Move.Right;
  } else return diffY < 0 ? Move.Down : Move.Up;
}

export default {
  doTurn,
};
