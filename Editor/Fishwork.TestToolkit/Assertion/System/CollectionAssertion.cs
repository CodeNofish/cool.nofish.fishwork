using System.Collections.Generic;
using System.Linq;

namespace Fishwork.TestToolkit {

  public class CollectionAssertion<TSubject> : ObjectAssertion<IEnumerable<TSubject>, CollectionAssertion<TSubject>> {
    public CollectionAssertion(IEnumerable<TSubject> subject, string caller) : base(subject, caller) { }

    /// <summary>
    /// 包含指定元素
    /// </summary>
    public CollectionAssertion<TSubject> Contain(TSubject item) {
      if (Subject != null && Subject.Contains(item)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"包含元素 {item}", $"{Subject}");
      return this;
    }

    /// <summary>
    /// 包含指定数量的元素
    /// </summary>
    public CollectionAssertion<TSubject> HaveCount(int expected) {
      if (Subject != null && Subject.Count() != expected) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"存在 {expected} 个元素", $"{Subject?.Count() ?? 0}");
      return this;
    }
  }

}
