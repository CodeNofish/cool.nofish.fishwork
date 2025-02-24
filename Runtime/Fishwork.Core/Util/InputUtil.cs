using UnityEngine;

namespace Fishwork.Core {

  public static class InputUtil {
    #region Cursor
    /// <summary>
    /// 设置自定义光标 
    /// </summary>
    public static void SetCursor(Texture2D cursorTexture,Vector2 hotSpot) {
      Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    /// <summary>
    /// 恢复默认光标
    /// </summary>
    public static void ResetCursor() {
      Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    /// <summary>
    /// 锁定光标
    /// </summary>
    public static void SetCursorLocked() {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
    
    /// <summary>
    /// 解锁光标
    /// </summary>
    public static void SetCursorUnlocked() {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
    }
    #endregion
  }

}
