from enum import Enum
from typing import List, Optional
from pydantic import BaseModel


class PackageType(Enum):
    Red = 0
    Green = 1
    Blue = 2
    Purple = 3


class TileInfo(BaseModel):
    # x coordinate of the tile
    x: int
    # y coordinate of the tile
    y: int
    # is this a storage spot (is drone allowed to drop a package here)
    droppable: bool


class DroneState(BaseModel):
    # id of the drone (globally unique)
    id: int
    # x coordinate of the drone
    x: int
    # y coordinate of the drone
    y: int
    # id of the package this drone is holding. 'None' if drone is not holding anything
    holding: Optional[int] = None


class PackageState(BaseModel):
    # id of the package (globally unique)
    id: int
    # x coordinate of the package
    x: int
    # y coordinate of the package
    y: int
    # type of the package
    type: PackageType
    # id of the drone currently holding this package. 'None' if package is not being carried
    heldBy: Optional[int] = None


class ExpectedDelivery(BaseModel):
    # x coordinate of the drop spot
    x: int
    # y coordinate of the drop spot
    y: int
    # type of the package expected in this spot
    type: PackageType


class TurnState(BaseModel):
    # width of the map
    mapWidth: int
    # height of the map
    mapHeight: int
    # array of all tiles on the map
    tiles: List[TileInfo]
    # current turn number
    turn: int
    # array of all drones' state
    drones: List[DroneState]
    # array of all packages' state
    packages: List[PackageState]
    # array of delivery locations that must be filled before the next delivery
    expectedDeliveries: List[ExpectedDelivery]
    # at which turn the next set of package will come
    nextIncomingAt: int
    # at which turn the current expectedDeliveries should be completed
    nextDeliveryAt: int
