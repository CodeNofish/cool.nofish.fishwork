using System;
using System.Collections.Generic;

namespace Fishwork.Core {

  public static class DictionaryExtension {
    /// <summary>
    /// 合并多个字典，返回新的字典
    /// </summary>
    public static Dictionary<K, V> MergeDictionaries<K, V>(this IEnumerable<KeyValuePair<K, V>> firstDict, params IEnumerable<KeyValuePair<K, V>>[] otherDict) {
      var result = new Dictionary<K, V>();
      foreach (var pair in firstDict)
        result[pair.Key] = pair.Value;
      foreach (var other in otherDict)
      foreach (var pair in other)
        result[pair.Key] = pair.Value;
      return result;
    }
    
    /// <summary>
    /// 转换字典的键，返回新的字典
    /// </summary>
    public static Dictionary<K, V> TransformKeys<K, V>(this Dictionary<K, V> origDict, Func<K, K> transform) {
      var result = new Dictionary<K, V>();
      foreach (var pair in origDict)
        result.Add(transform(pair.Key), pair.Value);
      return result;
    }
  }

}
