using System.Collections.Generic;
using Fishwork.Core;
using UnityEngine;

namespace Fishwork.Log {

  /// <summary>
  /// 日志管理器
  /// </summary>
  public class LoggerManager {
    private readonly List<ILogger> _loggers = new();
    private LogLevel _minimumLogLevel = LogLevel.Debug; // 默认记录所有日志
    private LogContext _context;

    public void SetMinimumLogLevel(LogLevel level) {
      _minimumLogLevel = level;
    }

    public void AddLogger(ILogger logger) {
      _loggers.Add(logger);
    }

    public void RemoveLogger(ILogger logger) {
      _loggers.Remove(logger);
    }

    public void Log(LogLevel level, string message) {
      // 过滤日志
      if (level < _minimumLogLevel) return;

      foreach (var logger in _loggers) {
        logger.Log(level, _context, message);
      }
    }

    public LogContext GetContext() {
      return _context;
    }

    public void SetContext(LogContext context) {
      _context = context;
    }
  }

}
