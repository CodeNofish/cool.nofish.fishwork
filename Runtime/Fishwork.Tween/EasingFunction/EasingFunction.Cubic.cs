using System;

namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseInCubic(float t) {
      return t * t * t;
    }

    public static float EaseOutCubic(float t) {
      return 1 - MathF.Pow(1 - t, 3);
    }

    public static float EaseInOutCubic(float t) {
      return t < 0.5f ? 4 * t * t * t : 1 - MathF.Pow(-2 * t + 2, 3) / 2;
    }
  }

}
