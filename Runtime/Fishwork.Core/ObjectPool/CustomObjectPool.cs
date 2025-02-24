// using System;
// using System.Collections.Generic;
// using System.Threading;
// using UnityEngine;
//
// namespace Fishwork.Core {
//

//
//   public class CustomObjectPool<T> : IObjectPool<IPooledObject<T>> where T : class, new() {
//     private readonly Queue<PooledObject<T>> _queue;
//     private readonly ReaderWriterLockSlim _lock = new();
//     private readonly int _maxSize;
//
//
//     public IPooledObject<T> Borrow() {
//       _lock.EnterReadLock();
//       try {
//         while (_queue.Count > 0) {
//           var pooledObj = _queue.Dequeue();
//           if (!pooledObj.IsExpired()) // 检查对象是否过期
//           {
//             Application.
//             pooledObj.Activate();
//             return pooledObj;
//           } else {
//             Console.WriteLine("Discarding expired object.");
//           }
//         }
//       } finally {
//         _lock.ExitReadLock();
//       }
//     }
//
//     public void Return(IPooledObject<T> obj) { }
//   }
//
//   public interface IPooledObjectFactory<T> where T : class, new() {
//     public IPooledObject<T> MakeObject();
//     public bool ValidateObject(IPooledObject<T> pooledObject);
//     public bool ActivateObject(IPooledObject<T> pooledObject);
//     public bool PassivateObject(IPooledObject<T> pooledObject);
//     public void DestroyObject(IPooledObject<T> pooledObject);
//   }
//
//   public interface IKeyedObjectFactory<K, T> where T : class, new() {
//     public IPooledObject<T> MakeObject(K key);
//     public bool ValidateObject(K key, IPooledObject<T> pooledObject);
//     public bool ActivateObject(K key, IPooledObject<T> pooledObject);
//     public bool PassivateObject(K key, IPooledObject<T> pooledObject);
//     public void DestroyObject(K key, IPooledObject<T> pooledObject);
//   }
//
//   public interface IPooledObject<T> : IDisposable where T : class {
//     public T GetObject();
//     
//   }
//
//   public class SimplePooledObject<T> : IPooledObject<T> where T : class {
//     private T _object;
//
//     public T GetObject() {
//       return _object;
//     }
//
//     public void Dispose() { }
//   }
//
//   public class PooledObject<T> where T : class {
//     public T Object { get; private set; }
//     public bool IsActive { get; private set; }
//     public DateTimeOffset CreationTime { get; private set; }
//     public DateTimeOffset LastUsedTime { get; private set; }
//     public int UsageCount { get; private set; } = 0;
//   }
//
// }
