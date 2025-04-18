using System.Threading;

namespace Fishwork.TestToolkit {

  public static class AssertionScope {
    /// <summary>
    /// 当前断言域
    /// </summary>
    public static ThreadLocal<BaseAssertionScope> CurrentScope = new(() => RootScope);

    /// <summary>
    /// 根断言域
    /// </summary>
    public static readonly RootAssertionScope RootScope = new();

    public static AndAssertionScope SatisfyAll() {
      return new AndAssertionScope();
    }
    
    public static OrAssertionScope SatisfyAny() {
      return new OrAssertionScope();
    }
  }

}
