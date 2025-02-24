using System.Collections.Generic;

namespace Fishwork.Core {

  public static class ListExtension {
    /// <summary>
    /// 填充元素 
    /// </summary>
    public static void Populate<T>(this IList<T> list, T item) {
      int count = list.Count;
      for (int i = 0; i < count; i++)
        list[i] = item;
    }
  }

}
