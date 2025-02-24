using System;

namespace Fishwork.Core {

  /// <summary>
  /// Fishwork内部异常的基类
  /// </summary>
  public abstract class FishworkException : Exception {
    public FishworkException() { }
    public FishworkException(string message) : base(message) { }
    public FishworkException(string message, Exception innerException) : base(message, innerException) { }
  }

}
