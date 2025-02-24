using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fishwork.Core {

  /// <summary>
  /// 验证参数
  /// </summary>
  public static class Guard {
    /// <summary>
    /// 验证参数是否为 null 
    /// </summary>
    [DebuggerStepThrough]
    public static void AgainstNull(object argument, string argumentName) {
      if (argument == null)
        throw new ArgumentNullException(argumentName, $"{argumentName} 不能为 null");
    }

    /// <summary>
    /// 验证字符串是否为 null 或空
    /// </summary>
    [DebuggerStepThrough]
    public static void AgainstNullOrEmpty(string argument, string argumentName) {
      if (string.IsNullOrEmpty(argument))
        throw new ArgumentException($"{argumentName} 不能为 null 或空字符串", argumentName);
    }

    /// <summary>
    /// 验证字符串是否为 null、空或空白
    /// </summary>
    [DebuggerStepThrough]
    public static void AgainstNullOrWhiteSpace(string argument, string argumentName) {
      if (string.IsNullOrWhiteSpace(argument))
        throw new ArgumentException($"{argumentName} 不能为 null、空字符串或空白", argumentName);
    }

    /// <summary>
    /// 验证数值是否为正数
    /// </summary>
    [DebuggerStepThrough]
    public static void AgainstNegativeOrZero(int argument, string argumentName) {
      if (argument <= 0)
        throw new ArgumentException($"{argumentName} 必须为正数", argumentName);
    }

    /// <summary>
    /// 验证数值是否为负数
    /// </summary>
    [DebuggerStepThrough]
    public static void AgainstNegative(int argument, string argumentName) {
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
    /// 验证数值是否在指定范围内
    /// </summary>
    [DebuggerStepThrough]
    public static void AgainstOutOfRange(int argument, int min, int max, string argumentName) {
      if (argument < min || argument > max)
        throw new ArgumentException($"{argumentName} 必须在 {min} 和 {max} 之间", argumentName);
    }

    /// <summary>
    /// 验证集合是否为 null 或空
    /// </summary>
    [DebuggerStepThrough]
    public static void AgainstNullOrEmptyCollection<T>(IEnumerable<T> collection, string argumentName) {
      if (collection == null || !collection.Any())
        throw new ArgumentException($"{argumentName} 不能为 null 或空集合", argumentName);
    }

    /// <summary>
    /// 验证对象是否满足指定条件
    /// </summary>
    [DebuggerStepThrough]
    public static void AgainstInvalid<T>(T argument, Func<T, bool> validationFunc, string argumentName, string message = null) {
      if (!validationFunc(argument))
        throw new ArgumentException(message ?? $"{argumentName} 无效", argumentName);
    }

    /// <summary>
    /// 验证字符串是否符合正则表达式
    /// </summary>
    public static void AgainstInvalidFormat(string argument, string pattern, string argumentName, string message = null) {
      if (!Regex.IsMatch(argument, pattern))
        throw new ArgumentException(message ?? $"{argumentName} 格式无效", argumentName);
    }

    /// <summary>
    /// 验证枚举值是否有效
    /// </summary>
    public static void AgainstInvalidEnumValue<TEnum>(TEnum value, string argumentName, string message = null) where TEnum : Enum {
      if (!Enum.IsDefined(typeof(TEnum), value))
        throw new ArgumentException(message ?? $"{argumentName} 不是有效的 {typeof(TEnum).Name} 值", argumentName);
    }

    /// <summary>
    ///  验证文件路径是否存在
    /// </summary>
    public static void AgainstFileNotFound(string filePath, string argumentName, string message = null) {
      if (!File.Exists(filePath))
        throw new FileNotFoundException(message ?? $"{argumentName} 文件未找到: {filePath}", filePath);
    }

    /// <summary>
    /// 验证目录是否存在
    /// </summary>
    public static void AgainstDirectoryNotFound(string directoryPath, string argumentName, string message = null) {
      if (!Directory.Exists(directoryPath))
        throw new DirectoryNotFoundException(message ?? $"{argumentName} 目录未找到: {directoryPath}");
    }

    /// <summary>
    /// 验证日期时间是否在指定范围内
    /// </summary>
    public static void AgainstDateOutOfRange(DateTime date, DateTime minDate, DateTime maxDate, string argumentName, string message = null) {
      if (date < minDate || date > maxDate)
        throw new ArgumentOutOfRangeException(argumentName, message ?? $"{argumentName} 必须在 {minDate} 和 {maxDate} 之间");
    }

    /// <summary>
    /// 验证类型是否可以转换为目标类型
    /// </summary>
    public static void AgainstInvalidCast<TTarget>(object value, string argumentName, string message = null) {
      if (value is not TTarget)
        throw new InvalidCastException(message ?? $"{argumentName} 无法转换为 {typeof(TTarget).Name}");
    }
  }

}
