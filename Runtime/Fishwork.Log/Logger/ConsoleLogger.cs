using System;

namespace Fishwork.Log {

  /// <summary>
  /// 基于System.Console的日志记录器
  /// </summary>
  public class ConsoleLogger : ILogger {
    private readonly ILogFormatter _formatter;

    public ConsoleLogger(ILogFormatter formatter) {
      _formatter = formatter;
    }

    public void Log(LogLevel level,LogContext context, string message) {
      string formattedMessage = _formatter.Format(level,context, message);
      Console.WriteLine(formattedMessage);
    }
  }

}
