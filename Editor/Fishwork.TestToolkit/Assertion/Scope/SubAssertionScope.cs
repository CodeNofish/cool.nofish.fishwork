using System.Collections.Generic;

namespace Fishwork.TestToolkit {

  public abstract class SubAssertionScope : BaseAssertionScope {
    // 当前断言域 出现的错误
    public readonly List<BaseAssertionFailureMessage> FailureMessageList = new();
    // 每个断言是否成功
    public readonly List<bool> SuccessList = new();

    public SubAssertionScope() {
      Parent = AssertionScope.CurrentScope.Value;
      AssertionScope.CurrentScope.Value = this;
    }

    public override void ReportFailure(BaseAssertionFailureMessage failureMessage) {
      FailureMessageList.Add(failureMessage);
      SuccessList.Add(false);
    }

    public override void ReportSuccess() {
      SuccessList.Add(true);
    }

    public override void Dispose() {
      AssertionScope.CurrentScope.Value = Parent;
    }
  }

}
