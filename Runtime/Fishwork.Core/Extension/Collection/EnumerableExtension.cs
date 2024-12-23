using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Fishwork.Core {

  public static class EnumerableExtension {
    /// <summary>
    /// 获取IEnumerable元素数量，优先使用非枚举方法
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetCount<T>(this IEnumerable<T> sequence) {
      return sequence switch {
        ICollection<T> collection => collection.Count,
        ICollection collection2 => collection2.Count,
        _ => sequence.Count()
      };
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Do<T>(this IEnumerable<T> sequence, Action<T> action) {
      if (sequence is null) return;
      foreach (var item in sequence) action(item);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DoIf<T>(this IEnumerable<T> sequence, Func<T, bool> condition, Action<T> action) {
      sequence?.Where(condition).Do(action);
    }
  }

}
