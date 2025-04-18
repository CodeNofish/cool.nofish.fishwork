namespace Fishwork.TestToolkit {

  /// <summary>
  /// 在RootAssertionScope中，提交断言方法时 直接执行
  /// </summary>
  public class RootAssertionScope : BaseAssertionScope {
    public RootAssertionScope() {
      Parent = this;
    }

    public override void ReportFailure(BaseAssertionFailureMessage failure) {
      AssertionEngine.ThrowException(AssertionEngine.FormatFailure(failure));
    }

    public override void ReportSuccess() { }

    public override void Dispose() { }
  }

}
