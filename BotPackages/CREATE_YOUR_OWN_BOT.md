# Instruction for creating your own bot

Some bootstrap packages are available to quickly get you into the game. But if you don't like any of the languages available, or prefer to use your own project structure, you can follow the instruction here to create your own bot.

Behind the scene, the bot for AMA Jo is just a RESTful server.

Any server satisfying the following requirement can work as the bot:

- A RESTful server listening on **http://localhost:1337/**
- All endpoints must Accept `application/json` and reply response Content-Type `application/json`
- POST `/captcha` accept `{ question: string }` and reply with `{ answer: string }`
- POST `/do-turn` accept `TurnState` (check `Typescript/types/turn-state.dto.ts`) and reply with `TurnDecision` (check `Typescript/types/turn-decision.dto.ts`)
