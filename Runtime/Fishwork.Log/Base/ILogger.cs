namespace Fishwork.Log {

  public interface ILogger {
    public void Log(LogLevel level, LogContext context, string message);
  }

}
