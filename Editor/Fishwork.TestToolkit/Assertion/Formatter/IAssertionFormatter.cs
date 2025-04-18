namespace Fishwork.TestToolkit {

  /// <summary>
  /// 断言格式化器 
  /// </summary>
  public interface IAssertionFormatter {
    /// <summary>
    /// 格式化一条 断言失败消息
    /// </summary>
    public string Format(BaseAssertionFailureMessage message);
  }

}
