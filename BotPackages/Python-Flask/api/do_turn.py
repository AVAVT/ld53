import random
from model.TurnState import DroneState, PackageState, TurnState
from model.TurnDecision import DroneDecision, Move, TurnDecision


def do_turn(turn_state: TurnState) -> TurnDecision:
    return TurnDecision(
        droneDecisions=list(
            map(
                lambda drone: DroneDecision(
                    id=drone.id,
                    move=Move.PickOrDrop
                    if drone.holding == None
                    and any(package_under_drone(p, drone) for p in turn_state.packages)
                    else random.randrange(4) + 1,
                ),
                turn_state.drones,
            )
        )
    )


def package_under_drone(pkg: PackageState, drone: DroneState):
    return pkg.x == drone.x and pkg.y == drone.y
