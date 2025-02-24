using System;
using System.IO;

namespace Fishwork.Log {

  /// <summary>
  /// 按日期轮转的文件日志记录器
  /// </summary>
  public class DateFileLogger : ILogger {
    private readonly string _baseFilePath;
    private readonly ILogFormatter _formatter;
    private string _currentFilePath;

    public DateFileLogger(string baseFilePath, ILogFormatter formatter) {
      _baseFilePath = baseFilePath;
      _formatter = formatter;
      UpdateFilePath();
    }

    private void UpdateFilePath() {
      string date = DateTime.Now.ToString("yyyy-MM-dd");
      _currentFilePath = $"{_baseFilePath}.{date}.log";
    }

    public void Log(LogLevel level, LogContext context, string message) {
      // 检查日期是否变化
      if (!File.Exists(_currentFilePath)) {
        UpdateFilePath();
      }

      string formattedMessage = _formatter.Format(level, context, message);
      File.AppendAllText(_currentFilePath, formattedMessage + Environment.NewLine);
    }
  }

}
