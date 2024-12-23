using System;

namespace Fishwork.Core {

  /// <summary>
  /// 数组相关工具
  /// </summary>
  public static class ArrayUtil {
    /// <summary>
    /// 复制子序列，返回新数组
    /// </summary>
    public static T[] Copy<T>(T[] array, int start, int length) {
      if (start + length > array.Length)
        length = array.Length - start;
      T[] newArray = new T[length];
      Array.Copy(array, start, newArray, 0, length);
      return newArray;
    }

    /// <summary>
    /// 插入元素，返回新数组
    /// </summary>
    public static T[] InsertAt<T>(T[] array, int position, T item) {
      T[] newArray = new T[array.Length + 1];
      if (position > 0)
        Array.Copy(array, newArray, position);
      if (position < array.Length)
        Array.Copy(array, position, newArray, position + 1, array.Length - position);
      newArray[position] = item;
      return newArray;
    }

    /// <summary>
    /// 插入多个元素，返回新数组
    /// </summary>
    public static T[] InsertAt<T>(T[] array, int position, T[] items) {
      T[] newArray = new T[array.Length + items.Length];
      if (position > 0)
        Array.Copy(array, newArray, position);
      if (position < array.Length)
        Array.Copy(array, position, newArray, position + items.Length, array.Length - position);
      items.CopyTo(newArray, position);
      return newArray;
    }

    /// <summary>
    /// 追加元素，返回新数组
    /// </summary>
    public static T[] Append<T>(T[] array, T item) {
      return InsertAt(array, array.Length, item);
    }

    /// <summary>
    /// 追加多个元素，返回新数组
    /// </summary>
    public static T[] Append<T>(T[] array, T[] items) {
      return InsertAt(array, array.Length, items);
    }

    /// <summary>
    /// 移除元素，返回新数组
    /// </summary>
    public static T[] RemoveAt<T>(T[] array, int position, int length = 1) {
      if (position + length > array.Length)
        length = array.Length - position;
      T[] newArray = new T[array.Length - length];
      if (position > 0)
        Array.Copy(array, newArray, position);
      if (position < newArray.Length)
        Array.Copy(array, position + length, newArray, position, newArray.Length - position);
      return newArray;
    }

    /// <summary>
    /// 替换元素，返回新数组
    /// </summary>
    public static T[] ReplaceAt<T>(T[] array, int position, T item) {
      T[] newArray = new T[array.Length];
      Array.Copy(array, newArray, array.Length);
      newArray[position] = item;
      return newArray;
    }

    /// <summary>
    /// 替换多个元素，返回新数组
    /// </summary>
    public static T[] ReplaceAt<T>(T[] array, int position, int length, T[] items) {
      return InsertAt(RemoveAt(array, position, length), position, items);
    }

    /// <summary>
    /// 逆向排序元素，返回原数组
    /// </summary>
    public static void Reverse<T>(T[] array) {
      Reverse(array, 0, array.Length);
    }

    /// <summary>
    /// 逆向排序元素，返回原数组
    /// </summary>
    public static void Reverse<T>(T[] array, int start, int count) {
      int end = start + count - 1;
      for (int i = start, j = end; i < j; i++, j--)
        (array[i], array[j]) = (array[j], array[i]);
    }
  }

}
