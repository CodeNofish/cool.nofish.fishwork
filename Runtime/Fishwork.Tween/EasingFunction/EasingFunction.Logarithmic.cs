using System;

namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseInLog(float t) {
      return MathF.Log10(9 * t + 1);
    }

    public static float EaseOutLog(float t) {
      return 1 - MathF.Log10(10 - 9 * t);
    }

    public static float EaseInOutLog(float t) {
      return t < 0.5f
        ? MathF.Log10(9 * t * 2 + 1) / 2
        : 1 - MathF.Log10(10 - 9 * (t - 0.5f) * 2) / 2;
    }
  }

}
