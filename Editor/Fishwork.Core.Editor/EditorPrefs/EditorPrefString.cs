using System.Collections.Generic;
using UnityEditor;

namespace Fishwork.Core.Editor {

  public class EditorPrefString {
    private readonly string _key;
    private string _value;
    private readonly string _default;

    private EditorPrefString(string key, string @default) {
      _key = key;
      _default = @default;
    }

    private static Dictionary<string, EditorPrefString> _cache = new();

    public static EditorPrefString Of(string key, string @default = "") {
      if (_cache.ContainsKey(key)) {
        var pref = _cache[key];
        pref.Update();
        return pref;
      } else {
        var pref = new EditorPrefString(key, @default);
        pref.Update();
        _cache.Add(key, pref);
        return pref;
      }
    }

    public string Value {
      get { return _value; }
      set {
        _value = value;
        Save();
      }
    }

    public void Save() {
      EditorPrefs.SetString(_key, Value);
    }

    public void Update() {
      _value = EditorPrefs.GetString(_key, _default);
    }

    public void Delete() {
      EditorPrefs.DeleteKey(_key);
    }
  }

}
