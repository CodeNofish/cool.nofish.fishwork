using System;
using System.Collections;
using System.Collections.Generic;

namespace Fishwork.Core {

  public class ListChangedEventArgs<T> : EventArgs {
    public readonly int Index;
    public readonly T Item;

    public ListChangedEventArgs(int index, T item) {
      Index = index;
      Item = item;
    }
  }

  public delegate void ListChangedEventHandler<T>(ObservableList<T> sender, ListChangedEventArgs<T> e);

  public class ObservableList<T> : IList<T> {
    private readonly IList<T> _list;

    public event ListChangedEventHandler<T> OnItemAdded;
    public event ListChangedEventHandler<T> OnItemRemoved;

    public ObservableList() : this(0) { }
    
    public ObservableList(int capacity) {
      _list = new List<T>(capacity);
    }
    
    public ObservableList(IEnumerable<T> collection) {
      _list = new List<T>(collection);
    }
    
    public ObservableList(IList<T> list) {
      _list = list;
    }
    
    public IEnumerator<T> GetEnumerator() {
      return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return GetEnumerator();
    }

    public void Add(T item) {
      _list.Add(item);
      OnEvent(OnItemAdded, _list.IndexOf(item), item);
    }
    
    public void Add(params T[] items) {
      foreach (var i in items)
        Add(i);
    }

    public void Clear() {
      while (Count > 0)
        RemoveAt(Count - 1);
    }

    public bool Contains(T item) {
      return _list.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex) {
      _list.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item) {
      int index = _list.IndexOf(item);
      bool ret = _list.Remove(item);
      if (ret)
        OnEvent(OnItemRemoved, index, item);
      return ret;
    }

    public int Remove(params T[] items) {
      if (items == null) return 0;
      int count = 0;
      foreach (var i in items)
        count += Remove(i) ? 1 : 0;
      return count;
    }
    
    public int Count {
      get => _list.Count;
    }
    
    public bool IsReadOnly {
      get => false;
    }

    public int IndexOf(T item) {
      return _list.IndexOf(item);
    }

    public void Insert(int index, T item) {
      _list.Insert(index, item);
      OnEvent(OnItemAdded, index, item);
    }

    public void RemoveAt(int index) {
      var item = _list[index];
      _list.RemoveAt(index);
      OnEvent(OnItemRemoved, index, item);
    }

    public T this[int index] {
      get { return _list[index]; }
      set {
        OnEvent(OnItemRemoved, index, _list[index]);
        _list[index] = value;
        OnEvent(OnItemAdded, index, value);
      }
    }

    protected void OnEvent(ListChangedEventHandler<T> e, int index, T item) {
      e?.Invoke(this, new ListChangedEventArgs<T>(index, item));
    }
  }

}
