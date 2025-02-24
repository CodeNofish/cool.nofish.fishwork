using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Fishwork.Core {

  /// <summary>
  /// 验证参数
  /// </summary>
  public static class Guard {
    /// <summary>
    /// 验证参数是否为 null 
    /// </summary>
    [DebuggerStepThrough]
    public static void NotNull(object argument, string argumentName) {
      if (argument == null)
        throw new ArgumentNullException(argumentName, $"{argumentName} 不能为 null");
    }

    /// <summary>
    /// 验证字符串是否为 null 或空
    /// </summary>
    [DebuggerStepThrough]
    public static void NotEmpty(string argument, string argumentName) {
      if (string.IsNullOrEmpty(argument))
        throw new ArgumentException($"{argumentName} 不能为 null 或空字符串", argumentName);
    }

    /// <summary>
    /// 验证字符串是否为 null、空或空白
    /// </summary>
    [DebuggerStepThrough]
    public static void NotBlank(string argument, string argumentName) {
      if (string.IsNullOrWhiteSpace(argument))
        throw new ArgumentException($"{argumentName} 不能为 null、空字符串或空白", argumentName);
    }

    /// <summary>
    /// 验证数值是否为正数
    /// </summary>
    [DebuggerStepThrough]
    public static void IsPositive(int argument, string argumentName) {
      if (argument <= 0)
        throw new ArgumentException($"{argumentName} 必须为正数", argumentName);
    }

    /// <summary>
    /// 验证数值是否为负数
    /// </summary>
    [DebuggerStepThrough]
    public static void NotNegative(int argument, string argumentName) {
      if (argument < 0)
        throw new ArgumentException($"{argumentName} 不能为负数", argumentName);
    }

    /// <summary>
    /// 验证条件是否为 true，如果为 true 则抛出异常
    /// </summary>
    [DebuggerStepThrough]
    public static void AgainstCondition(bool condition, string message, string argumentName) {
      if (condition)
        throw new ArgumentException(message, argumentName);
    }
    
    /// <summary>
    /// 验证条件是否为 true，如果为 false 则抛出异常
    /// </summary>
    [DebuggerStepThrough]
    public static void Condition(bool condition, string message, string argumentName) {
      if (!condition)
        throw new ArgumentException(message, argumentName);
    }

    /// <summary>
    /// 检查参数是否在指定范围内，如果不在范围内则抛出 ArgumentOutOfRangeException
    /// </summary>
    [DebuggerStepThrough]
    public static void InRange<T>(T value, T min, T max, string paramName) where T : IComparable<T> {
      if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
        throw new ArgumentOutOfRangeException(paramName, $"{paramName} 必须在 {min} 和 {max} 之间");
    }

    /// <summary>
    /// 检查参数是否为有效的 GUID
    /// </summary>
    [DebuggerStepThrough]
    public static void IsValidGuid(Guid guid, string paramName) {
      if (guid == Guid.Empty)
        throw new ArgumentException($"{paramName} 不是有效的 GUID", paramName);
    }

    /// <summary>
    /// 检查参数序列里是否包含空
    /// </summary>
    [DebuggerStepThrough]
    public static void ElementNotNull<T>(IEnumerable<T> value, string paramName) where T : class {
      if (value == null)
        throw new ArgumentNullException(paramName);
      if (value.Any(e => e == null))
        throw new ArgumentException(paramName, $"{paramName} 序列不能包含空元素");
    }

    /// <summary>
    /// 检查参数是否为某个子类型
    /// </summary>
    [DebuggerStepThrough]
    public static void IsSubType<TBase>(object value, string paramName) {
      if (value == null)
        throw new ArgumentNullException(paramName, $"{paramName} 不能为 null");
      if (!(value is TBase))
        throw new ArgumentException($"{paramName} 必须是 {typeof(TBase).Name} 的子类型", paramName);
    }

    /// <summary>
    /// 检查参数是否实现了某个接口
    /// </summary>
    [DebuggerStepThrough]
    public static void ImplementsInterface<TInterface>(object value, string paramName) {
      if (value == null)
        throw new ArgumentNullException(paramName, $"{paramName} 不能为 null");
      if (!(value is TInterface))
        throw new ArgumentException($"{paramName} 必须实现 {typeof(TInterface).Name} 接口", paramName);
    }
  }

}
