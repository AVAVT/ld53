import express from "express";
import bodyParser from "body-parser";
import captcha from "./api/captcha";
import doTurn from "./api/do-turn";

const PORT = 1337;
const app = express();
app.use(bodyParser.json());

app.get("/", (req, res) => {
  res.send("The bot is working properly!");
});

app.post("/captcha", async (req, res) => {
  res.send(await captcha(req.body.question));
});

app.post("/do-turn", async (req, res) => {
  res.send(await doTurn(req.body));
});

app.listen(PORT, () => {
  console.log(`The bot is listening on port ${PORT}!`);
});
