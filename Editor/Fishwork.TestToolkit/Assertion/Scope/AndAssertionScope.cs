using System.Linq;

namespace Fishwork.TestToolkit {

  public class AndAssertionScope : SubAssertionScope {
    public override void Dispose() {
      base.Dispose();
      // 没有子断言 || 有子断言并且都成功
      if (SuccessList.Count == 0 || SuccessList.All(success => success)) {
        Parent.ReportSuccess();
        return;
      }
   
      // 报告消息
      if (FailureMessageList.Count == 1) {
        Parent.ReportFailure(FailureMessageList.First());
      } else {
        var failure = new MultiAssertionFailureMessage {
          LogicalOperator = LogicalOperator.And,
          Messages = FailureMessageList,
        };
        Parent.ReportFailure(failure);
      }
    }
  }

}
