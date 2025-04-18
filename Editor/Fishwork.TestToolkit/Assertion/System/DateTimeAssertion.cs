using System;

namespace Fishwork.TestToolkit {

  public class DateTimeAssertion : BaseAssertion<DateTime, DateTimeAssertion> {
    public DateTimeAssertion(DateTime subject, string caller) : base(subject, caller) { }

    /// <summary>
    /// 在指定精度下相等
    /// </summary>
    public DateTimeAssertion BeWithin(TimeSpan precision, DateTime expected) {
      var difference = (expected - Subject).Duration();
      if (difference <= precision) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"在精度 {precision} 下, 和 {expected} 相等 (差值: {difference})", $"差值: {difference}");
      return this;
    }

    /// <summary>
    /// 是UTC时间
    /// </summary>
    public DateTimeAssertion BeUtc() {
      if (Subject.Kind != DateTimeKind.Utc) {
        ReportSuccess();
        return this;
      }
      ReportFailure("是 UTC 时间", $"{Subject.Kind}");
      return this;
    }
  }

}
