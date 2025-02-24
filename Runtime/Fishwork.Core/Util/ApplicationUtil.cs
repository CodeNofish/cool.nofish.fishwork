using UnityEngine;

namespace Fishwork.Core {

  public static class ApplicationUtil {
    /// <summary>
    /// 设置帧率
    /// </summary>
    public static void SetFrameRate(int frameRate) {
      Application.targetFrameRate = frameRate;
    }
  }

}
