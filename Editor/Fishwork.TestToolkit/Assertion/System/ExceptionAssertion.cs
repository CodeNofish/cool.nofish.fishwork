using System;

namespace Fishwork.TestToolkit {

  public class ExceptionAssertion<TSubject> : ObjectAssertion<Exception, ExceptionAssertion<TSubject>> where TSubject : Exception {
    public ExceptionAssertion(TSubject subject, string caller) : base(subject, caller) { }

    /// <summary>
    /// 包含制定错误消息
    /// </summary>
    public ExceptionAssertion<TSubject> WithMessageContaining(string text) {
      if (Subject != null && Subject.Message.Contains(text)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"异常消息内包含 '{text}'");
      return this;
    }
  }

}
