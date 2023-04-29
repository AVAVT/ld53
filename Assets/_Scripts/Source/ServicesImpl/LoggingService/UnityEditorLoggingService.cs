using System;
using UnityEngine;

public class UnityEditorLoggingService : ILoggingService
{
  public void Error(Exception exception) => Debug.LogException(exception);
  public void Error(string message) => Debug.LogError(message);
  public void Log(string message) => Debug.Log(message);
  public void Warning(Exception exception) => Debug.LogWarning(exception);
  public void Warning(string message) => Debug.LogWarning(message);
}