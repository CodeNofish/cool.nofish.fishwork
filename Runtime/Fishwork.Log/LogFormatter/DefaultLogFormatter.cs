using System;
using System.Linq;

namespace Fishwork.Log {
  
  /// <summary>
  /// 默认的日志格式 
  /// </summary>
  public class DefaultLogFormatter : ILogFormatter {
    public string Format(LogLevel level,LogContext context, string message) {
      var contextInfo = string.Join(", ", context.GetAll().Select(kv => $"{kv.Key}={kv.Value}"));
      return $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{level}] [{contextInfo}] {message}";
    }
  }

}
