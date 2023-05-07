from flask import Flask, jsonify, request

from api.captcha import captcha
from api.do_turn import do_turn
from model.TurnState import TurnState

app = Flask(__name__)
PORT = 1337


@app.route("/")
def health_route():
    return "The bot is working properly!"


@app.post("/captcha")
def captcha_route():
    return jsonify(captcha(request.get_json()))


@app.post("/do-turn")
def do_turn_route():
    json = request.get_json()
    turn_state = TurnState(**json)
    return do_turn(turn_state).json()


if __name__ == "__main__":
    app.run(debug=True, port=PORT)
