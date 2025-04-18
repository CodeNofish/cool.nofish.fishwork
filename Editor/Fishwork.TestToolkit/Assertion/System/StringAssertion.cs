using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fishwork.TestToolkit {

  public sealed class StringAssertion : ObjectAssertion<string, StringAssertion> {
    public StringAssertion(string subject, string caller) : base(subject, caller) { }

    /// <summary>
    /// 字符串相等
    /// </summary>
    public StringAssertion Be(string expected, StringComparison comparison = StringComparison.Ordinal) {
      if (Subject == null && expected == null) {
        ReportSuccess();
        return this;
      }
      if (Subject != null && expected != null && Subject.Equals(expected, comparison)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"'{expected}'", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言字符串为空字符串
    /// </summary>
    public StringAssertion BeEmpty() {
      if (Subject != null && string.IsNullOrEmpty(Subject)) {
        ReportSuccess();
        return this;
      }
      ReportFailure("空字符串", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言为null或空字符串
    /// </summary>
    public StringAssertion BeNullOrEmpty() {
      if (string.IsNullOrEmpty(Subject)) {
        ReportSuccess();
        return this;
      }
      ReportFailure("null或空字符串", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言为null、空或仅含空白字符
    /// </summary>
    public StringAssertion BeNullOrWhiteSpace() {
      if (string.IsNullOrWhiteSpace(Subject)) {
        ReportSuccess();
        return this;
      }
      ReportFailure("null、空或仅含空白字符", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言包含特定子串
    /// </summary>
    public StringAssertion Contain(string substring) {
      if (Subject.Contains(substring)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"包含子串 '{substring}'", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言不包含特定子串
    /// </summary>
    public StringAssertion NotContain(string substring) {
      if (!Subject.Contains(substring)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"不包含子串 '{substring}'", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言以某子串开头
    /// </summary>
    public StringAssertion StartWith(string prefix) {
      if (Subject.StartsWith(prefix)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"有以下前缀 '{prefix}'", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言以某子串结尾
    /// </summary>
    public StringAssertion EndWith(string suffix) {
      if (Subject.EndsWith(suffix)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"有以下后缀 '{suffix}'", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言符合正则表达式
    /// </summary>
    public StringAssertion Match(string pattern) {
      if (Subject != null && Regex.IsMatch(Subject, pattern)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"符合正则表达式 '{pattern}'", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言不符合正则表达式
    /// </summary>
    public StringAssertion NotMatch(string pattern) {
      if (Subject != null && !Regex.IsMatch(Subject, pattern)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"不符合正则表达式 '{pattern}'", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言是Base64编码字符串
    /// </summary>
    public StringAssertion BeBase64String() {
      const string pattern = @"^[A-Za-z0-9+/]+={0,2}$";
      if (Subject != null && Subject.Length % 4 == 0 && Regex.IsMatch(Subject, pattern)) {
        bool convertSuccess = false;
        try {
          _ = Convert.FromBase64String(Subject);
          convertSuccess = true;
        } catch (Exception) {
          // ignored
        }
        if (convertSuccess) {
          ReportSuccess();
          return this;
        }
      }
      ReportFailure("不符合Base64编码字符串", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言仅含十六进制字符
    /// </summary>
    public StringAssertion BeHexadecimal() {
      if (Subject != null && Subject.ToCharArray().All(Uri.IsHexDigit)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"仅含十六进制字符", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言仅含字母
    /// </summary>
    public StringAssertion ConsistOfLetters() {
      if (Subject != null && Subject.ToCharArray().All(char.IsLetter)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"仅包含字母'", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言仅含数字
    /// </summary>
    public StringAssertion ConsistOfDigits() {
      if (Subject != null && Subject.ToCharArray().All(char.IsDigit)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"仅含数字", $"'{Subject}'");
      return this;
    }


    /// <summary>
    /// 断言仅含字母数字
    /// </summary>
    public StringAssertion ConsistOfLetterOrDigit() {
      if (Subject != null && Subject.ToCharArray().All(char.IsLetterOrDigit)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"仅含字母数字", $"'{Subject}'");
      return this;
    }

    /// <summary>
    /// 断言长度等于某值
    /// </summary>
    public StringAssertion HaveLength(int expectedLength) {
      if (Subject != null && Subject.Length == expectedLength) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"长度等于 '{expectedLength}'", $"'{Subject?.Length ?? 0}'");
      return this;
    }

    /// <summary>
    /// 断言长度大于
    /// </summary>
    public StringAssertion HaveLengthGreaterThan(int min) {
      if (Subject != null && Subject.Length > min) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"长度大于 '{min}'", $"'{Subject?.Length ?? 0}'");
      return this;
    }

    /// <summary>
    /// 断言长度小于
    /// </summary>
    public StringAssertion HaveLengthLessThan(int max) {
      if (Subject != null && Subject.Length < max) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"长度小于 '{max}'", $"'{Subject?.Length ?? 0}'");
      return this;
    }

    /// <summary>
    /// 断言行数符合预期
    /// </summary>
    public StringAssertion HaveLineCount(int expectedLines) {
      int lineCount = 0;
      if (Subject != null) {
        using (var reader = new StringReader(Subject)) {
          while (reader.ReadLine() != null) lineCount++;
        }
        if (lineCount == expectedLines) {
          ReportSuccess();
          return this;
        }
      }

      ReportFailure($"行数等于 {expectedLines}", $"{lineCount}");
      return this;
    }

    /// <summary>
    /// 断言包含某行内容
    /// </summary>
    public StringAssertion ContainLine(string expectedLine, StringComparison comparison = StringComparison.Ordinal) {
      if (Subject != null) {
        using (var reader = new StringReader(Subject)) {
          while (reader.ReadLine() is { } line) {
            if (line.Equals(expectedLine, comparison)) {
              ReportSuccess();
              return this;
            }
          }
        }
      }
      ReportFailure($"包含以下行 '{expectedLine}'");
      return this;
    }
  }

}
