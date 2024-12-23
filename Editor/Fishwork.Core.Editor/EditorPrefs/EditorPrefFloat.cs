using System.Collections.Generic;
using UnityEditor;

namespace Fishwork.Core.Editor {

  public class EditorPrefFloat {
    private readonly string _key;
    private float _value;
    private readonly float _default;

    private EditorPrefFloat(string key, float @default) {
      _key = key;
      _default = @default;
    }

    private static Dictionary<string, EditorPrefFloat> _cache = new();

    public static EditorPrefFloat Of(string key, float @default = 0.0f) {
      if (_cache.ContainsKey(key)) {
        var pref = _cache[key];
        pref.Update();
        return pref;
      } else {
        var pref = new EditorPrefFloat(key, @default);
        pref.Update();
        _cache.Add(key, pref);
        return pref;
      }
    }

    public float Value {
      get { return _value; }
      set {
        _value = value;
        Save();
      }
    }

    public void Save() {
      EditorPrefs.SetFloat(_key, Value);
    }

    public void Update() {
      _value = EditorPrefs.GetFloat(_key, _default);
    }

    public void Delete() {
      EditorPrefs.DeleteKey(_key);
    }
  }

}
