from enum import Enum
from typing import List
from pydantic import BaseModel


class Move(Enum):
    PickOrDrop = 0
    Up = 1
    Right = 2
    Down = 3
    Left = 4


class DroneDecision(BaseModel):
    # id of the drone you're giving command to
    id: int
    # action the drone should take
    move: Move


class TurnDecision(BaseModel):
    # array of commands given to drones
    droneDecisions: List[DroneDecision]
