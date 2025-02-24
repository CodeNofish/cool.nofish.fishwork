using System;
using System.IO;

namespace Fishwork.Log {

  /// <summary>
  /// 基于文件的日志记录器
  /// </summary>
  public class FileLogger : ILogger {
    private readonly string _filePath;
    private readonly ILogFormatter _formatter;

    public FileLogger(string filePath, ILogFormatter formatter) {
      _filePath = filePath;
      _formatter = formatter;
    }

    public void Log(LogLevel level,LogContext context, string message) {
      string formattedMessage = _formatter.Format(level, context,message);
      File.AppendAllText(_filePath, formattedMessage + Environment.NewLine);
    }
  }

}
