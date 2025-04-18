using System;

namespace Fishwork.TestToolkit {

  public class NumericAssertion<TSubject> : BaseAssertion<TSubject, NumericAssertion<TSubject>> where TSubject : struct, IComparable<TSubject> {
    public NumericAssertion(TSubject subject, string caller) : base(subject, caller) { }

    /// <summary>
    /// 相等
    /// </summary>
    public NumericAssertion<TSubject> Be(TSubject expected) {
      if (Subject.CompareTo(expected) == 0) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"{expected}", $"{Subject}");
      return this;
    }

    /// <summary>
    /// 在指定范围内
    /// </summary>
    public NumericAssertion<TSubject> BeInRange(TSubject min, TSubject max) {
      if (Subject.CompareTo(min) >= 0 && Subject.CompareTo(max) <= 0) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"值在区间 [{min}, {max}] 中", $"{Subject}");
      return this;
    }

    /// <summary>
    /// 为正数
    /// </summary>
    public NumericAssertion<TSubject> BePositive() {
      if (Subject.CompareTo(default) > 0) {
        ReportSuccess();
        return this;
      }
      ReportFailure("值为正数", $"{Subject}");
      return this;
    }
  }

}
