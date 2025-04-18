namespace Fishwork.TestToolkit {

  public class ReferenceTypeAssertion<TSubject> : ReferenceTypeAssertion<TSubject, ReferenceTypeAssertion<TSubject>> where TSubject : class {
    protected ReferenceTypeAssertion(TSubject subject, string caller) : base(subject, caller) { }
  }

  public class ReferenceTypeAssertion<TSubject, TAssertion> : BaseAssertion<TSubject, TAssertion>
    where TAssertion : BaseAssertion<TSubject, TAssertion> where TSubject : class {
    protected ReferenceTypeAssertion(TSubject subject, string caller) : base(subject, caller) { }

    /// <summary>
    /// 为Null
    /// </summary>
    public TAssertion BeNull() {
      if (Subject == null) {
        ReportSuccess();
        return this as TAssertion;
      }
      ReportFailure("null");
      return this as TAssertion;
    }

    /// <summary>
    /// 非Null
    /// </summary>
    public TAssertion NotNull() {
      if (Subject != null) {
        ReportSuccess();
        return this as TAssertion;
      }
      ReportFailure("非null");
      return this as TAssertion;
    }

    /// <summary>
    /// 引用相等
    /// </summary>
    public TAssertion RefEqualTo(TSubject expected) {
      if (ReferenceEquals(Subject, expected)) {
        ReportSuccess();
        return this as TAssertion;
      }
      ReportFailure($"和 {expected} 引用相等");
      return this as TAssertion;
    }

    /// <summary>
    /// 引用不相等
    /// </summary>
    public TAssertion NotRefEqualTo(TSubject expected) {
      if (!ReferenceEquals(Subject, expected)) {
        ReportSuccess();
        return this as TAssertion;
      }
      ReportFailure($"和 {expected} 引用不相等");
      return this as TAssertion;
    }

    /// <summary>
    /// 引用不相等
    /// </summary>
    public TAssertion BeTypeOf<TExpected>() {
      if (Subject != null && Subject.GetType() == typeof(TExpected)) {
        ReportSuccess();
        return this as TAssertion;
      }
      ReportFailure($"类型是 {typeof(TExpected).Name}", $"{Subject?.GetType()}");
      return this as TAssertion;
    }

    /// <summary>
    /// 断言对象可转换为某类型（如基类或接口）
    /// </summary>
    public TAssertion BeAssignableTo<TExpected>() {
      if (Subject is TExpected) {
        ReportSuccess();
        return this as TAssertion;
      }
      ReportFailure($"可转换为 {typeof(TExpected).Name}", $"{Subject?.GetType()}");
      return this as TAssertion;
    }
  }

}
