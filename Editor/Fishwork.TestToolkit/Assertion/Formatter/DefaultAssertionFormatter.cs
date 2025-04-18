  namespace Fishwork.TestToolkit {

  /// <summary>
  /// 默认的断言格式化器
  /// </summary>
  internal class DefaultAssertionFormatter : IAssertionFormatter {
    public string Format(BaseAssertionFailureMessage message) {
      var builder = new IntendedStringBuilder();
      FormatMsg(message, builder);
      return builder.ToString();
    }

    private static void FormatMsg(BaseAssertionFailureMessage message, IntendedStringBuilder builder) {
      switch (message) {
      case SingleAssertionFailureMessage singleMessage: {
        builder.AppendIntent()
          .Append("断言失败: ").Append(singleMessage.Subject)
          .Append(" 预期为 ").Append(singleMessage.ShouldBe);
        // 可选 打印Fact
        if (!string.IsNullOrEmpty(singleMessage.Fact)) 
          builder.Append(" , 但事实为 ").Append(singleMessage.Fact);
        builder.AppendLine();
        break;
      }
      case MultiAssertionFailureMessage multiMessage: {
        var messagesCount = multiMessage.Messages.Count;
        var logical = multiMessage.LogicalOperator;
        // 打印多条断言如何组合起来的
        switch (logical) {
        case LogicalOperator.And:
          builder.AppendIntent().AppendLine($"[断言失败 因为需要同时满足以下断言]");
          break;
        case LogicalOperator.Or:
          builder.AppendIntent().AppendLine($"[断言失败 因为需要满足以下任一断言]");
          break;
        default:
          builder.AppendIntent().AppendLine($"[断言失败 因为以下{message}个断言]");
          break;
        }
        builder.IncreaseIndent();
        foreach (var subMessage in multiMessage.Messages)
          FormatMsg(subMessage, builder);
        builder.DecreaseIndent();
        break;
      }
      }
    }
  }

}
