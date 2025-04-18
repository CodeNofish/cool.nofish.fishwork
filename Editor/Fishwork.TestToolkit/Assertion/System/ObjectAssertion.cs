using System.Linq;

namespace Fishwork.TestToolkit {

  public class ObjectAssertion<TSubject> : ObjectAssertion<object, ObjectAssertion<object>> {
    public ObjectAssertion(object subject, string caller) : base(subject, caller) { }
  }

  public class ObjectAssertion<TSubject, TAssertions> : ReferenceTypeAssertion<TSubject, TAssertions>
    where TAssertions : ObjectAssertion<TSubject, TAssertions> where TSubject : class {
    public ObjectAssertion(TSubject subject, string caller) : base(subject, caller) { }

    /// <summary>
    /// 对象相等
    /// </summary>
    public TAssertions EqualTo(TSubject expected) {
      if (Equals(Subject, expected)) {
        ReportSuccess();
        return (TAssertions)this;
      }
      ReportFailure($"和 {expected} 相等");
      return (TAssertions)this;
    }

    /// <summary>
    /// 对象不相等
    /// </summary>
    public TAssertions NotEqualTo(TSubject expected) {
      if (!Equals(Subject, expected)) {
        ReportSuccess();
        return (TAssertions)this;
      }
      ReportFailure($"和 {expected} 不相等");
      return (TAssertions)this;
    }

    /// <summary>
    /// 是以下期望值之一
    /// </summary>
    public TAssertions IsOneOf(params TSubject[] expectedValues) {
      if (expectedValues != null && expectedValues.Contains(Subject)) {
        ReportSuccess();
        return (TAssertions)this;
      }
      ReportFailure($"包含在 {expectedValues} 中");
      return (TAssertions)this;
    }
  }

}
