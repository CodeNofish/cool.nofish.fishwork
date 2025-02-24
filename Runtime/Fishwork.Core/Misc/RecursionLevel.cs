using System;

namespace Fishwork.Core {

  /// <summary>
  /// 递归级别超出范围
  /// </summary>
  public class RecursionLevelOutOfRangeException : FishworkException {
    public RecursionLevelOutOfRangeException(string message) : base(message) { }
  }

  /// <summary>
  /// 记录递归等级，超出时抛出异常
  /// </summary>
  public class RecursionLevel {
    public int CurLevel { get; private set; }
    public int MaxLevel { get; set; }

    public RecursionLevel(int maxLevel) {
      MaxLevel = maxLevel;
    }

    public void Increment() {
      if (!TryIncrement())
        throw new RecursionLevelOutOfRangeException("递归等级超出最大值");
    }

    public bool TryIncrement() {
      return CurLevel++ < MaxLevel;
    }

    public void Decrement() {
      if (CurLevel == 0)
        throw new RecursionLevelOutOfRangeException("递归等级已经为0了");
      CurLevel--;
    }
  }

}
