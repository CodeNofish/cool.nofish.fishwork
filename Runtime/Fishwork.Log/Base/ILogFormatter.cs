namespace Fishwork.Log {

  public interface ILogFormatter {
    public string Format(LogLevel level, LogContext context, string message);
  }

}
