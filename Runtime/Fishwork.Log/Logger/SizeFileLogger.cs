using System;
using System.IO;

namespace Fishwork.Log {

  /// <summary>
  /// 按文件大小轮转的文件日志记录器
  /// </summary>
  public class SizeFileLogger : ILogger {
    private readonly string _baseFilePath;
    private readonly ILogFormatter _formatter;
    private readonly long _maxFileSize;
    private int _fileIndex;

    public SizeFileLogger(string baseFilePath, ILogFormatter formatter, long maxFileSize) {
      _baseFilePath = baseFilePath;
      _formatter = formatter;
      _maxFileSize = maxFileSize;
      _fileIndex = 0;
    }

    private string GetCurrentFilePath() {
      return $"{_baseFilePath}.{_fileIndex}.log";
    }

    public void Log(LogLevel level, LogContext context, string message) {
      string currentFilePath = GetCurrentFilePath();

      // 检查文件大小
      if (File.Exists(currentFilePath) && new FileInfo(currentFilePath).Length >= _maxFileSize) {
        _fileIndex++;
        currentFilePath = GetCurrentFilePath();
      }

      string formattedMessage = _formatter.Format(level, context, message);
      File.AppendAllText(currentFilePath, formattedMessage + Environment.NewLine);
    }
  }

}
