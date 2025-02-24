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

    public static void Do<T>(this IEnumerable<T> sequence, Action<T> action) {
      if (sequence is null) return;
      foreach (var item in sequence) action(item);
    }

    public static void DoIf<T>(this IEnumerable<T> sequence, Func<T, bool> condition, Action<T> action) {
      sequence?.Where(condition).Do(action);
    }

    public static string JoinWith(this IEnumerable<string> sequence, string separator) {
      Guard.AgainstNull(sequence, nameof(sequence));
      Guard.AgainstNull(separator, nameof(separator));

      return string.Join(separator, sequence.ToArray());
    }

    public static IEnumerable<T> AppendItem<T>(this IEnumerable<T> sequence, T trailingItem) {
      Guard.AgainstNull(sequence, nameof(sequence));

      foreach (var t in sequence)
        yield return t;
      yield return trailingItem;
    }

    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> sequence, T leadingItem) {
      Guard.AgainstNull(sequence, nameof(sequence));

      yield return leadingItem;
      foreach (var t in sequence)
        yield return t;
    }
  }

}
