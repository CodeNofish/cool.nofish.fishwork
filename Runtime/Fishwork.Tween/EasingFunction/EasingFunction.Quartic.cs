using System;

namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseInQuart(float t) {
      return t * t * t * t;
    }

    public static float EaseOutQuart(float t) {
      return 1 - MathF.Pow(1 - t, 4);
    }

    public static float EaseInOutQuart(float t) {
      return t < 0.5f ? 8 * t * t * t * t : 1 - MathF.Pow(-2 * t + 2, 4) / 2;
    }
  }

}
