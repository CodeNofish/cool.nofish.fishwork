using System.Collections.Generic;
using UnityEditor;

namespace Fishwork.Core.Editor {

  public class EditorPrefInt {
    private readonly string _key;
    private int _value;
    private readonly int _default;

    private EditorPrefInt(string key, int @default) {
      _key = key;
      _default = @default;
    }

    private static Dictionary<string, EditorPrefInt> _cache = new();

    public static EditorPrefInt Of(string key, int @default = 0) {
      if (_cache.ContainsKey(key)) {
        var pref = _cache[key];
        pref.Update();
        return pref;
      } else {
        var pref = new EditorPrefInt(key, @default);
        pref.Update();
        _cache.Add(key, pref);
        return pref;
      }
    }

    public int Value {
      get { return _value; }
      set {
        _value = value;
        Save();
      }
    }

    public void Save() {
      EditorPrefs.SetInt(_key, Value);
    }

    public void Update() {
      _value = EditorPrefs.GetInt(_key, _default);
    }

    public void Delete() {
      EditorPrefs.DeleteKey(_key);
    }
  }

}
