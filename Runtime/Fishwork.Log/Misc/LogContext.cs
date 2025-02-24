using System.Collections.Generic;

namespace Fishwork.Log {

  /// <summary>
  /// 日志上下文
  /// </summary>
  public class LogContext {
    private readonly Dictionary<string, object> _context = new();

    public void Set(string key, object value) {
      _context[key] = value;
    }

    public object Get(string key) {
      return _context.GetValueOrDefault(key);
    }

    public IDictionary<string, object> GetAll() {
      return new Dictionary<string, object>(_context);
    }
  }

}
