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
    public static Dictionary<K, V> TransformKeys<K, V>(this IDictionary<K, V> origDict, Func<K, K> transform) {
      var result = new Dictionary<K, V>();
      foreach (var pair in origDict)
        result.Add(transform(pair.Key), pair.Value);
      return result;
    }
    
    /// <summary>
    /// 翻转字典的键值对
    /// </summary>
    public static Dictionary<V, K> Invert<K, V>(this IDictionary<K, V> origDict) {
      var dictionary = new Dictionary<V, K>();
      foreach (var pair in origDict) {
        if (!dictionary.ContainsKey(pair.Value)) 
          dictionary.Add(pair.Value, pair.Key);
      }
      return dictionary;
    }

    /// <summary>
    /// 获取键值对，找不到时用工厂方法添加新元素
    /// </summary>
    public static TValue GetOrAdd<TKey, TValue, TArg>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TArg, TValue> valueFactory, TArg arg) {
      Guard.AgainstNull(dictionary, nameof(dictionary));
      Guard.AgainstNull(key, nameof(key));
      Guard.AgainstNull(valueFactory, nameof(valueFactory));
      
      if (dictionary.TryGetValue(key, out var value)) return value;
      value = valueFactory(key, arg);
      dictionary.Add(key, value);
      return value;
    }
  }

}
