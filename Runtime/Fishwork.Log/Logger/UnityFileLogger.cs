using System;
using System.IO;
using UnityEngine;

namespace Fishwork.Log {

  /// <summary>
  /// 基于Unity.持久化目录的日志记录器 
  /// </summary>
  public class UnityFileLogger : ILogger {
    private readonly string _filePath;
    private readonly ILogFormatter _formatter;

    public UnityFileLogger(string fileName, ILogFormatter formatter) {
      _filePath = Path.Combine(Application.persistentDataPath, fileName);
      _formatter = formatter;
    }

    public void Log(LogLevel level, LogContext context, string message) {
      string formattedMessage = _formatter.Format(level, context, message);
      File.AppendAllText(_filePath, formattedMessage + Environment.NewLine);
    }
  }

}
