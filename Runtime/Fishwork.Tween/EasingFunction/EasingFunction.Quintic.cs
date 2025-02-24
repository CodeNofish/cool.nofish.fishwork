using System;

namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseInQuint(float t) {
      return t * t * t * t * t;
    }

    public static float EaseOutQuint(float t) {
      return 1 - MathF.Pow(1 - t, 5);
    }

    public static float EaseInOutQuint(float t) {
      return t < 0.5f ? 16 * t * t * t * t * t : 1 - MathF.Pow(-2 * t + 2, 5) / 2;
    }
  }

}
