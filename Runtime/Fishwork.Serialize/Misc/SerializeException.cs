using System;
using Fishwork.Core;

namespace Fishwork.Serialize {

  /// <summary>
  /// 序列化相关异常
  /// </summary>
  public class SerializeException : FishworkException {
    public SerializeException(string message) : base(message) { }
    public SerializeException(string message, Exception innerException) : base(message, innerException) { }

  }

}
