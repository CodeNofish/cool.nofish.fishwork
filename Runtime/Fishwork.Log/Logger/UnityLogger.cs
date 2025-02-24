using UnityEngine;

namespace Fishwork.Log {

  /// <summary>
  /// 基于Unity.Debug的日志记录器 
  /// </summary>
  public class UnityLogger : ILogger {
    private readonly ILogFormatter _formatter;

    public UnityLogger(ILogFormatter formatter) {
      _formatter = formatter;
    }

    public void Log(LogLevel level, LogContext context, string message) {
      string formattedMessage = _formatter.Format(level, context, message);

      switch (level) {
      case LogLevel.Debug:
      case LogLevel.Info:
        Debug.Log(formattedMessage);
        break;
      case LogLevel.Warn:
        Debug.LogWarning(formattedMessage);
        break;
      case LogLevel.Error:
      case LogLevel.Fatal:
        Debug.LogError(formattedMessage);
        break;
      }
    }
  }

}
