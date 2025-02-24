using System;
using System.Collections;
using System.Collections.Generic;

namespace Fishwork.Core {

  public class ObservableSet<T>: ISet<T> {
    public IEnumerator<T> GetEnumerator() {
      throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return GetEnumerator();
    }

    void ICollection<T>.Add(T item) {
      throw new NotImplementedException();
    }

    public void ExceptWith(IEnumerable<T> other) {
      throw new NotImplementedException();
    }

    public void IntersectWith(IEnumerable<T> other) {
      throw new NotImplementedException();
    }

    public bool IsProperSubsetOf(IEnumerable<T> other) {
      throw new NotImplementedException();
    }

    public bool IsProperSupersetOf(IEnumerable<T> other) {
      throw new NotImplementedException();
    }

    public bool IsSubsetOf(IEnumerable<T> other) {
      throw new NotImplementedException();
    }

    public bool IsSupersetOf(IEnumerable<T> other) {
      throw new NotImplementedException();
    }

    public bool Overlaps(IEnumerable<T> other) {
      throw new NotImplementedException();
    }

    public bool SetEquals(IEnumerable<T> other) {
      throw new NotImplementedException();
    }

    public void SymmetricExceptWith(IEnumerable<T> other) {
      throw new NotImplementedException();
    }

    public void UnionWith(IEnumerable<T> other) {
      throw new NotImplementedException();
    }

    bool ISet<T>.Add(T item) {
      throw new NotImplementedException();
    }

    public void Clear() {
      throw new NotImplementedException();
    }

    public bool Contains(T item) {
      throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex) {
      throw new NotImplementedException();
    }

    public bool Remove(T item) {
      throw new NotImplementedException();
    }

    public int Count { get; }
    public bool IsReadOnly { get; }
  }

}
