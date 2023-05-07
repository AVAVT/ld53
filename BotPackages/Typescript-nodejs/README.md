# AMA Jo game

AMA Jo is a bot-programming game, in which you (the main character) must disguise as an AI by writing a bot to seamlessly automate the stocking & delivery of packages in an AMJ's warehouse.

The game will progress through 5 days, in each day the task your bot must handle become progressively more complex.

Mistakes in managing the drones will raise suspicion from the SYSTEM. And when the SYSTEM has identified you as a human, it'd be game over.

# Installation (if you're new to nodejs)

This package is the template for a bot written in Typescript/nodejs.

1. Install nodejs at https://nodejs.org/ (either version is fine)

2. Open a command line at this root `Typescript-nodejs` folder and write

```
npm install
```

This will download/install all dependencies needed to run the bot.

3. After the installation is finished, you can start the bot server by writting:

```
npm run start
```

If you see this message printed on the console, the bot is ready:

```
Bot server is listening on port 1337!
```

# Gameplay

## Captcha - the tutorial

At the beginning of the game, you will encounter a captcha verification.

(This step also serve as a healthcheck for your bot before playing).

You will be given a question and must answer the question correctly.

Open `/api/captcha.ts` file and check out the function `captcha`:

```typescript
export default function captcha(data: { question: string }) {
  console.log(data);
  return { answer: "W-what do you mean?" };
}
```

Currently our main character is dumbfounded and can't give a good answer, but luckily the question is already logged to the console. We should be able to update the answer properly, right?

After you have updated the answer, don't forget to restart the bot server to run latest code. Press `CTRL+C` (or `Cmd+C`) to stop the process, then run the bot again with `npm run start`.

**Remember to restart your bot every time you make code changes**

## Main game

After passing through the captcha, the main game will start. Main game is handled in `/api/do-turn.ts` file.

### Specification

The game take place in a board of 27x17 size. Coordinate go from `{ x: -13, y: -8 }` (bottom left) to `{ x: 13, y: 8 }` (top right).

Each turn, the `doTurn` function will be called with `TurnState` of the current turn. Definition of the object and description of each field can be found in `/types/turn-state.dto.ts`

Your bot must return a `TurnDecision` object (`/types/turn-decision.dto.ts`) to issue orders for the drones.

- The time limit for returning `TurnDecision` is **250ms (milliseconds)**
- You don't have to issue order to all drones. Drones who do not receive an order in a turn will stay idle.

Drones can either:

- move around in 4 directions (`Move.Up`, `Move.Down` etc), or
- perform `Move.PickOrDrop` to pick up a package or drop the one it's carrying.

The game will pause when you focus another window. This is intended so you can hot-fix bugs in your bot in the middle of a game.

### Winning Conditions

To win a stage, **you must successfully complete all deliveries of the day** without making too many mistakes.

Each day has several sets of delivery.

- Current set of deliveries are described in `turnState.expectedDeliveries`
- The deadline for current set of delivery is described in `turnState.nextDeliveryAt`
- To complete an `ExpectedDelivery`, your drone must carry a package of the correct type to that exact delivery spot.
- As long as the correct package is at the correct spot on the delivery turn, delivery can be completed (Even if your drone is still holding the package at that time)

Packages mostly come from the import truck, which come in fairly regularly inverval (jam value: every 100 turns). The turn when import car come is described in `turnState.nextIncomingAt`.

Incoming packages dropped by the import car should be stocked into the warehouse asap, because the next incoming car will destroy all packages in its path.

### Losing Conditions

1. **Timeout**: if at any time during gameplay your bot fails to reply within 250ms, it's instant gameover.
2. **No drone remaining**: Some mistakes will destroy your drones. If you have no remaining drone, it's instant gameover.
3. **Suspicion threshold reached**. (at Jam time this equals making 5 mistakes)

Following is the list of mistakes that will raise suspicion value. Most of them also destroy a drone, or a package. Drone holding a package will always be destroyed along with the package.

- Drone wander out of bound: Moving any drone out of the `{ x: -13, y: -8 }` to `{ x: 13, y: 8 }` warehouse area will trigger the drone's self-destruct sequence. **Drone will be destroyed**, obviously.
- Multiple command issue to same drone: The drone's embeded memory is extremely tiny and cannot handle multiple commands in the same turn. Doing so will overload the chip and **destroy the drone**.
- Issuing command to non-existing drone: this doesn't cause any harm to AMJ but it make the SYSTEM question your intelligence and suspect you might be of some lesser race (like human).
- Dropoff in forbidden area: `TileInfo.droppable` describe whether a tile can be used for package storage. Dropping a package on pathway (`droppable == false`) will trigger the automatic cleanup sequence and **destroy that package**.
- Multiple drone pickup: ordering multiple drone to pickup the same package will cause them to tear the package apart, **destroying package**.
- Package collision: while drones are agile and can easily move into the same spot, they're not agile enough when carrying a package. Moving a package into the same spot with another package will cause collision, **destroying both packages** along with drones carrying them.
- Collision with import truck: when a new import truck arrives, it will destroy all packages on its path (Jam values: `{x: -12}` to `{x: -10}` collumns). Note that each package destroyed this way count as 1 mistake.
- Incorrect delivery: failing to move package into delivery spot in time, or moving incorrect `PackageType` there count as a mistake.

## Stages

This section describes the challenges in each day and serve as a kind of supportive hint. If you like to overcome challenges as they come this can be safely skipped.

### Day 1

In this day, the task is quite simple: import and delivery trucks come and matching intervals, and there are only Red packages.

To pass this day, you need only control the drones to bring packages from the import zone to the delivery spots.

`/example-bots/simple-bot.ts` contains code written by your unfortunate predecessor, which can safely help you through this day.

### Day 2

You now have 2 drones and move packages are needed per delivery.

The simple bot example won't be able to help you from now on, mostly because of package collision.

To pass this day, you will need to implement some proper pathfinding algorithm and collision avoidance.

The most famous pathfinding algorithms for this kind of map are A\* (A Star) and BFS (Breadth-first Search). Either will be able to help you through this stage.

### Day 3

Packages start coming in 2 different colors in this stage.

The challenge in this stage is to quickly store unneeded package into a storage area, to avoid collsion with the next import truck.

If you haven't created a cache of the map tiles (in a different format from an Array) for easy access, doing so will help you manage which storage space are available.

### Day 4 & Day 5

These days' information are kept as secret
