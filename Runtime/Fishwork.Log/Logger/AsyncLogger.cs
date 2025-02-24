using System.Threading.Tasks;

namespace Fishwork.Log {

  /// <summary>
  /// 异步日志记录器
  /// </summary>
  public class AsyncLogger : ILogger {
    private readonly ILogger _innerLogger;

    public AsyncLogger(ILogger innerLogger) {
      _innerLogger = innerLogger;
    }

    public void Log(LogLevel level, LogContext context, string message) {
      Task.Run(() => _innerLogger.Log(level, context, message));
    }
  }

}
