using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Fishwork.Core {

  public static class SequenceExtension {
    /// <summary>
    /// 获取IEnumerable元素数量，优先使用非枚举方法
    /// </summary>
    public static int GetCount<T>(this IEnumerable<T> sequence) {
      return sequence switch {
        ICollection<T> collection => collection.Count,
        ICollection collection2 => collection2.Count,
        _ => sequence.Count()
      };
    }
    
    /// <summary>
    /// 返回单个元素的序列
    /// </summary>
    public static IEnumerable<T> Yield<T>(this T item) {
      yield return item;
    }

    #region 遍历
    /// <summary>
    /// 遍历序列
    /// </summary>
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> sequence, Action<T> action) {
      foreach (var item in sequence)
        action(item);
      return sequence;
    }

    /// <summary>
    /// 遍历序列，传入计数
    /// </summary>
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> sequence, Action<T, int> action, int start = 0) {
      int counter = start;
      foreach (var item in sequence)
        action(item, counter++);
      return sequence;
    }

    /// <summary>
    /// 遍历序列，传入计数，传入函数返回步进长度
    /// </summary>
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> sequence, Func<T, int, int> action, int start = 0) {
      int counter = start;
      foreach (var item in sequence) {
        int add = action(item, counter);
        counter += add;
      }
      return sequence;
    }
    #endregion

    #region 转换对象
    public static IEnumerable<T> Convert<T>(this IEnumerable sequence, Func<object, T> converter) {
      foreach (var item in sequence)
        yield return converter(item);
    }
    
    public static IEnumerable<TTo> Convert<TFrom, TTo>(this IEnumerable<TFrom> sequence, Func<TFrom, TTo> converter) {
      foreach (var item in sequence)
        yield return converter(item);
    }
    
    public static IEnumerable<T> FilterCast<T>(this IEnumerable source) {
      foreach (var obj in source) {
        if (obj is T castedObj)
          yield return castedObj;
      }
    }
    #endregion

    #region 前置追加
    public static IEnumerable<T> PrependWith<T>(this IEnumerable<T> sequence, Func<T> prepend) {
      yield return prepend();
      foreach (var item in sequence)
        yield return item;
    }

    public static IEnumerable<T> PrependWith<T>(this IEnumerable<T> sequence, T prepend) {
      yield return prepend;
      foreach (var item in sequence)
        yield return item;
    }

    public static IEnumerable<T> PrependWith<T>(this IEnumerable<T> sequence, IEnumerable<T> prepend) {
      foreach (var item in prepend)
        yield return item;
      foreach (var item in sequence)
        yield return item;
    }

    public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> sequence, bool condition, Func<T> prepend) {
      if (condition)
        yield return prepend();
      foreach (var item in sequence)
        yield return item;
    }

    public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> sequence, bool condition, T prepend) {
      if (condition)
        yield return prepend;
      foreach (var item in sequence)
        yield return item;
    }

    public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> sequence, bool condition, IEnumerable<T> prepend) {
      if (condition) {
        foreach (var item in prepend)
          yield return item;
      }
      foreach (var item in sequence)
        yield return item;
    }
    #endregion

    #region 后置追加
    public static IEnumerable<T> AppendWith<T>(this IEnumerable<T> sequence, Func<T> append) {
      foreach (var item in sequence)
        yield return item;
      yield return append();
    }

    public static IEnumerable<T> AppendWith<T>(this IEnumerable<T> sequence, T append) {
      foreach (var item in sequence)
        yield return item;
      yield return append;
    }
    
    public static IEnumerable<T> AppendWith<T>(this IEnumerable<T> sequence, IEnumerable<T> append) {
      foreach (var item in sequence)
        yield return item;
      foreach (var item in append)
        yield return item;
    }
    
    public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> sequence, bool condition, Func<T> append) {
      foreach (var item in sequence)
        yield return item;
      if (condition)
        yield return append();
    }
    
    public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> sequence, bool condition, T append) {
      foreach (var item in sequence)
        yield return item;
      if (condition)
        yield return append;
    }

    public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> sequence, bool condition, IEnumerable<T> append) {
      foreach (var item in sequence)
        yield return item;
      if (condition) {
        foreach (var item in append)
          yield return item;
      }
    }
    #endregion
  }

}
