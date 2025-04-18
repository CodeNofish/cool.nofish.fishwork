using System.Collections.Generic;

namespace Fishwork.TestToolkit {

  public enum LogicalOperator {
    And,
    Or,
  }

  public class BaseAssertionFailureMessage { }

  public class SingleAssertionFailureMessage : BaseAssertionFailureMessage {
    public string Subject;
    public string ShouldBe;
    public string Fact;
  }

  public class MultiAssertionFailureMessage : BaseAssertionFailureMessage {
    public LogicalOperator LogicalOperator;
    public List<BaseAssertionFailureMessage> Messages;
  }

}
