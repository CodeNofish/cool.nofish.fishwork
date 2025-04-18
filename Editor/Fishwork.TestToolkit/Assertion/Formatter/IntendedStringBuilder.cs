using System;
using System.Text;

namespace Fishwork.TestToolkit {

  /// <summary>
  /// 可以打印缩进的StringBuilder
  /// </summary>
  internal class IntendedStringBuilder {
    private readonly string _intent;
    private readonly StringBuilder _builder;
    private int _currentIndentLevel;

    internal IntendedStringBuilder(string indentUnit = "  ") {
      _intent = indentUnit;
      _builder = new StringBuilder();
      _currentIndentLevel = 0;
    }

    internal IntendedStringBuilder AppendLine(string text) {
      _builder.AppendLine(text);
      return this;
    }

    internal IntendedStringBuilder AppendLine() {
      _builder.AppendLine();
      return this;
    }

    internal IntendedStringBuilder Append(string text) {
      _builder.Append(text);
      return this;
    }

    internal IntendedStringBuilder IncreaseIndent() {
      _currentIndentLevel++;
      return this;
    }

    internal IntendedStringBuilder DecreaseIndent() {
      _currentIndentLevel = Math.Max(0, _currentIndentLevel - 1);
      return this;
    }

    internal IntendedStringBuilder AppendIntent() {
      for (int i = 0; i < _currentIndentLevel; i++)
        _builder.Append(_intent);
      return this;
    }

    public override string ToString() {
      return _builder.ToString();
    }
  }

}
