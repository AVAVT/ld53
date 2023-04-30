﻿using System;
using System.Text;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class RemoteAiService : IAiService
{
  const int PORT = 1337;
  static readonly string Server = $"localhost:{PORT}";

  public RemoteAiService(Contexts contexts)
  {
  }

  public async Task<string> Captcha(string question) => await SendRequest<string>("captcha", JsonConvert.SerializeObject(new CaptchaDto { question = question }));

  public async Task<TurnDecision> DoTurn(TurnStateDto state) => await SendRequest<TurnDecision>("do-turn", JsonConvert.SerializeObject(state));

  static async Task<T> SendRequest<T>(string endpoint, string json)
  {
    var data = new UTF8Encoding().GetBytes(json);

    using var req = new UnityWebRequest($"http://{Server}/{endpoint}", "POST");

    req.uploadHandler = new UploadHandlerRaw(data);
    req.downloadHandler = new DownloadHandlerBuffer();
    req.SetRequestHeader("Content-Type", "application/json");

    await req.SendWebRequest();

    if (req.result == UnityWebRequest.Result.ConnectionError)
      throw new($"Error While Sending: {req.error}");

    return JsonConvert.DeserializeObject<T>(req.downloadHandler.text);
  }
}