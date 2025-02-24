using System.Collections.Generic;

namespace Fishwork.Core {

  /// <summary>
  /// 简易但高效的对象池，不支持线程安全
  /// </summary>
  public class SimpleObjectPool<T> : IObjectPool<T> where T : class, new() {
    private readonly Queue<T> _queue;
    private readonly int _maxSize;

    public SimpleObjectPool(int maxSize) {
      _queue = new Queue<T>();
      _maxSize = maxSize;
    }

    public T Borrow() {
      if (_queue.Count > 0)
        return _queue.Dequeue();
      return new T();
    }

    public void Return(T obj) {
      if (_queue.Count < _maxSize)
        _queue.Enqueue(obj);
    }
  }

}
