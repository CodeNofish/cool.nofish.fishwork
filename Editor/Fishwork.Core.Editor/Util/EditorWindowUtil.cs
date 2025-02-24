using UnityEditor;
using UnityEngine;

namespace Fishwork.Core.Editor {

  public static class EditorWindowUtil {
    /// <summary>
    /// 当前屏幕分辨率大小
    /// </summary>
    public static readonly Vector2 ResolutionSize = new(Screen.currentResolution.width, Screen.currentResolution.height);
    
    /// <summary>
    /// 居中窗口
    /// </summary>
    /// <param name="window">目标窗口</param>
    /// <param name="windowSize">窗口大小 百分比</param>
    public static void SetWindowCenterAlign(this EditorWindow window, float windowSize) {
      float windowWidth = ResolutionSize.x * windowSize;
      float windowHeight = ResolutionSize.y * windowSize;
      
      float windowX = (ResolutionSize.x - windowWidth) * 0.5f;
      float windowY = (ResolutionSize.y - windowHeight) * 0.5f;
      
      window.position = new Rect(windowX, windowY, windowWidth, windowHeight);
    }

    /// <summary>
    /// 设置窗口最小大小
    /// </summary>
    public static void SetMinSize(this EditorWindow window, Vector2 minSize) {
      window.minSize = minSize;
    }
  }

}
