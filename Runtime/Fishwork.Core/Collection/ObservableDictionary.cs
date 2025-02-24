// using System;
// using System.Collections;
// using System.Collections.Generic;
//
// namespace Fishwork.Core {
//
//   public class DictionaryChangedEventArgs<TKey, TValue> : EventArgs {
//     public readonly TKey Key;
//     public readonly TValue Value;
//
//     public DictionaryChangedEventArgs(TKey key, TValue value) {
//       Key = key;
//       Value = value;
//     }
//   }
//
//   public delegate void DictionaryChangedEventHandler<TKey, TValue>(ObservableDictionary<TKey, TValue> sender, DictionaryChangedEventArgs<TKey, TValue> e);
//
//   public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue> {
//     private IDictionary<TKey, TValue> _dictionary;
//
//     public event DictionaryChangedEventHandler<TKey, TValue> OnItemAdded;
//     public event DictionaryChangedEventHandler<TKey, TValue> OnItemRemoved;
//     
//     public ObservableDictionary() : this(new Dictionary<TKey, TValue>()) { }
//
//     public ObservableDictionary(IDictionary<TKey, TValue> dictionary) {
//       _dictionary = dictionary;
//     }
//
//     public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
//       return _dictionary.GetEnumerator();
//     }
//
//     IEnumerator IEnumerable.GetEnumerator() {
//       return GetEnumerator();
//     }
//
//     public void Add(KeyValuePair<TKey, TValue> item) {
//       _dictionary.Add(item);
//       
//     }
//
//     public void Clear() {
//       throw new NotImplementedException();
//     }
//
//     public bool Contains(KeyValuePair<TKey, TValue> item) {
//       return _dictionary.Contains(item);
//     }
//
//     public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) {
//       _dictionary.CopyTo(array, arrayIndex);
//     }
//
//     public bool Remove(KeyValuePair<TKey, TValue> item) {
//       throw new NotImplementedException();
//     }
//
//     public int Count {
//       get => _dictionary.Count;
//     }
//
//     public bool IsReadOnly {
//       get => _dictionary.IsReadOnly;
//     }
//
//     public void Add(TKey key, TValue value) {
//       throw new NotImplementedException();
//     }
//
//     public bool ContainsKey(TKey key) {
//       return _dictionary.ContainsKey(key);
//     }
//
//     public bool Remove(TKey key) {
//       throw new NotImplementedException();
//     }
//
//     public bool TryGetValue(TKey key, out TValue value) {
//       throw new NotImplementedException();
//     }
//
//     public TValue this[TKey key] {
//       get => throw new NotImplementedException();
//       set => throw new NotImplementedException();
//     }
//
//     public ICollection<TKey> Keys {
//       get => _dictionary.Keys;
//     }
//
//     public ICollection<TValue> Values {
//       get => _dictionary.Values;
//     }
//     
//     protected void OnEvent(DictionaryChangedEventHandler<TKey, TValue> e, TKey key, TValue value) {
//       e?.Invoke(this, new DictionaryChangedEventHandler<TKey, TValue>(key, value));
//     }
//   }
//
// }
