using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Fishwork.TestToolkit {

  public static class FluentAssertionsExtension {
    public static ObjectAssertion<T> Should<T>(this object subject) => new(subject, GetCaller());

    public static StringAssertion Should(this string subject) => new(subject, GetCaller());

    public static CollectionAssertion<T> Should<T>(this IEnumerable<T> subject) => new(subject, GetCaller());

    public static NumericAssertion<T> Should<T>(this T subject) where T : struct, IComparable<T> => new(subject, GetCaller());

    public static DateTimeAssertion Should(this DateTime subject) => new(subject, GetCaller());

    internal static string GetCaller() {
      var stackTrace = new StackTrace(true);
      var caller = AssertionEngine.GetCallerExpression(stackTrace);
      return caller;
    }

    // TODO 异常断言
    // public static ExceptionAssertions Should(this Action action) {
    //   try {
    //     action();
    //     throw new AssertionException("Expected exception but completed normally");
    //   } catch (Exception ex) {
    //     return new ExceptionAssertions(ex);
    //   }
    // }
  }

}
