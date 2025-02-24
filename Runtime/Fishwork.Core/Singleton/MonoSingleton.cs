using UnityEngine;

namespace Fishwork.Core {

  /// <summary>
  /// 通过继承实现单例 
  /// </summary>
  public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour {
    private static T _instance;

    public static T Instance {
      get {
        if (_instance == null) {
          _instance = FindFirstObjectByType<T>();

          if (_instance == null) {
            GameObject singletonObject = new GameObject(typeof(T).Name);
            _instance = singletonObject.AddComponent<T>();
          }
        }
        return _instance;
      }
    }

    protected virtual void Awake() {
      if (_instance != null && _instance != this as T) {
        Destroy(gameObject);
      } else {
        _instance = this as T;
        DontDestroyOnLoad(gameObject);
      }
    }
  }

}
