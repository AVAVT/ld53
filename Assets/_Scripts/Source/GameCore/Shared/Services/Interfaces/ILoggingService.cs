using System;

public interface ILoggingService
{
  void Log(string message);
  void Error(Exception exception);
  void Error(string message);
  void Warning(Exception exception);
  void Warning(string message);
}