using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fishwork.Inspector.Editor {

  public class SplitViewWindow : EditorWindow {
    [MenuItem("Window/SplitView Example")]
    public static void ShowExample() {
      SplitViewWindow window = GetWindow<SplitViewWindow>();
      window.titleContent = new GUIContent("SplitView Window");
    }

    public void CreateGUI() {
      var root = rootVisualElement;

      // fixedPaneIndex：固定面板的索引（0表示左侧/上方，1表示右侧/下方）。
      // fixedPaneInitialDimension：固定面板的初始宽度或高度。
      var splitView = new TwoPaneSplitView(0, 200, TwoPaneSplitViewOrientation.Horizontal);

      var leftPanel = new VisualElement();
      leftPanel.style.backgroundColor = new Color(0.1f, 0.1f, 0.1f);
      leftPanel.style.flexGrow = 1.0f;
      leftPanel.Add(new Label("Left Panel"));

      var rightPanel = new VisualElement();
      rightPanel.style.backgroundColor = new Color(0.2f, 0.2f, 0.2f);
      rightPanel.style.flexGrow = 1;
      rightPanel.Add(new Label("Right Panel"));
      
      splitView.Add(leftPanel);
      splitView.Add(rightPanel);
      
      root.Add(splitView);
    }
  }

}
