using Fishwork.Core.Editor;
using UnityEditor;
using UnityEngine;

namespace Fishwork.Inspector {

  public class MyCustomEditorWindow : EditorWindow {
    private static readonly string MyWindowPosKey = "MyWindowPos";
    private EditorPrefObject<Rect> MyWindowPosPref = EditorPrefObject<Rect>.Of(MyWindowPosKey, Rect.zero);

    public string Title { get; set; } = "MY CUSTOM EDITOR";

    [MenuItem("Fishwork/My Custom Editor Window")]
    public static void ShowWindow() {
      var window = GetWindow<MyCustomEditorWindow>("My Custom Editor");
      window.SetWindowCenterAlign(0.5f);
    }

    public void F() { }

    // 在窗口的OnGUI方法中绘制UI
    private void OnGUI() {
      titleContent = new GUIContent(Title);

      GUILayout.Label("This is a custom editor window", EditorStyles.boldLabel);

      if (GUILayout.Button("Click Me")) {
        Debug.Log("Button clicked!");
      }

      // 添加更多的UI元素
      EditorGUILayout.TextField("Text Field", "Default Text");
      EditorGUILayout.Toggle("Toggle", true);
    }

    private void OnDestroy() {
      // 销毁窗口时 保存窗口位置
      // MyWindowPosPref.Delete();
      Rect position = this.position;
      Debug.Log(EditorJsonUtility.ToJson(position));
      MyWindowPosPref.Value = position;
      Debug.Log(EditorPrefs.GetString(MyWindowPosKey, string.Empty));
    }
  }

}
