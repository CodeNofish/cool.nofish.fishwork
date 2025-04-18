using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fishwork.TestToolkit {

  public static class AssertionEngine {
    public static readonly IAssertionFormatter Formatter = new DefaultAssertionFormatter();

    internal static readonly Lazy<Regex> ShouldRegex = new(() => new Regex(@"\s*(.*)\.Should(<.*>)?()", RegexOptions.Compiled));
    
    [DoesNotReturn]
    public static void ThrowException(string message) {
      throw new NUnit.Framework.AssertionException(message);
    }
    
    public static string FormatFailure(BaseAssertionFailureMessage message) {
      return Formatter.Format(message);
    }
    
    public static string GetCallerExpression(StackTrace stackTrace) {
      var frames = stackTrace.GetFrames();
      if (frames == null) return "unknown";

      try {
        for (int i = 0; i < frames.Length; i++) {
          var frame = frames[i];
          var method = frame.GetMethod();
          if (method.DeclaringType != typeof(FluentAssertionsExtension) || !method.Name.Contains("Should"))
            continue;
          if (i < frames.Length)
            return ParseCaller(frames[i + 1]);
        }
      } catch (Exception) {
        return "unknown";
      }
      return "unknown";
    }

    internal static string ParseCaller(StackFrame frame) {
      string fileName = frame.GetFileName();
      int lineNumber = frame.GetFileLineNumber();
      if (File.Exists(fileName)) {
        string codeLine = File.ReadLines(fileName).ElementAt(lineNumber - 1);

        // 处理类似于 var assertion = "Some".Should(); 
        var indexOfShould = codeLine.IndexOf(".Should", StringComparison.Ordinal);
        var indexOfEquals = codeLine.IndexOf("=", StringComparison.Ordinal);
        if (indexOfEquals >= 0 && indexOfEquals < indexOfShould)
          codeLine = codeLine.Substring(indexOfEquals + 1, codeLine.Length - indexOfEquals - 1);

        var match = ShouldRegex.Value.Match(codeLine);
        if (match.Success) return match.Groups[1].Value;
      }
      return "unknown";
    }
  }

}
