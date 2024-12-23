using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fishwork.Core.Editor {

  public class EditorPrefObject<T> {
    private readonly string _key;
    private T _value;
    private readonly T _default;

    private EditorPrefObject(string key, T @default) {
      _key = key;
      _default = @default;
    }

    private static Dictionary<string, EditorPrefObject<T>> _cache = new();

    public static EditorPrefObject<T> Of(string key, T @default) {
      if (_cache.ContainsKey(key)) {
        var pref = _cache[key];
        return pref;
      } else {
        var pref = new EditorPrefObject<T>(key, @default);
        _cache.Add(key, pref);
        return pref;
      }
    }

    public T Value {
      get { return _value; }
      set {
        _value = value;
        Save();
      }
    }

    public void Save() {
      // TODO JsonUtility 序列化不好用
      var json = JsonUtility.ToJson(_value, false);
      EditorPrefs.SetString(_key, json);
    }

    public void Update() {
      if (EditorPrefs.HasKey(_key)) {
        var json = EditorPrefs.GetString(_key);
        _value = JsonUtility.FromJson<T>(json);
      } else {
        _value = _default;
      }
    }

    public void Delete() {
      EditorPrefs.DeleteKey(_key);
    }
  }

}
