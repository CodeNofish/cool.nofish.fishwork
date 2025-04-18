using System;

namespace Fishwork.TestToolkit {

  public abstract class BaseAssertion<TSubject, TAssertion> where TAssertion : BaseAssertion<TSubject, TAssertion> {
    public TSubject Subject { get; }
    public string CallerIdentifier { get; }

    public BaseAssertion(TSubject subject, string callerIdentifier) {
      Subject = subject;
      CallerIdentifier = callerIdentifier;
    }

    /// <summary>
    /// 便捷方法，报告断言错误
    /// </summary>
    protected void ReportFailure(string shouldBe, string fact = null) {
      var failure = new SingleAssertionFailureMessage {
        Subject = CallerIdentifier,
        ShouldBe = shouldBe,
        Fact = fact,
      };
      AssertionScope.CurrentScope.Value.ReportFailure(failure);
    }

    /// <summary>
    /// 便捷方法，报告断言成功
    /// </summary>
    protected void ReportSuccess() {
      AssertionScope.CurrentScope.Value.ReportSuccess();
    }

    /// <summary>
    /// 满足任一断言
    /// </summary>
    public TAssertion Any(params Action<TAssertion>[] actions) {
      using (AssertionScope.SatisfyAny()) {
        foreach (var action in actions) {
          using (AssertionScope.SatisfyAll()) {
            action((TAssertion)this); 
          }
        }
      }
      return (TAssertion)this;
    }
  }

}
