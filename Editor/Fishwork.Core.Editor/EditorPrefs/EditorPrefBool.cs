using System.Collections.Generic;
using UnityEditor;

namespace Fishwork.Core.Editor {

  public class EditorPrefBool {
    private readonly string _key;
    private bool _value;
    private readonly bool _default;

    private EditorPrefBool(string key, bool @default) {
      _key = key;
      _default = @default;
    }

    private static Dictionary<string, EditorPrefBool> _cache = new();

    public static EditorPrefBool Of(string key, bool @default = false) {
      if (_cache.ContainsKey(key)) {
        var pref = _cache[key];
        pref.Update();
        return pref;
      } else {
        var pref = new EditorPrefBool(key, @default);
        pref.Update();
        _cache.Add(key, pref);
        return pref;
      }
    }

    public bool Value {
      get { return _value; }
      set {
        _value = value;
        Save();
      }
    }

    public void Save() {
      EditorPrefs.SetBool(_key, Value);
    }

    public void Update() {
      _value = EditorPrefs.GetBool(_key, _default);
    }

    public void Delete() {
      EditorPrefs.DeleteKey(_key);
    }
  }

}
