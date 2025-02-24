using System;

namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseInBack(float t) {
      const float c1 = 1.70158f;
      const float c3 = c1 + 1;

      return c3 * t * t * t - c1 * t * t;
    }

    public static float EaseOutBack(float t) {
      const float c1 = 1.70158f;
      const float c3 = c1 + 1;

      return 1 + c3 * MathF.Pow(t - 1, 3) + c1 * MathF.Pow(t - 1, 2);
    }

    public static float EaseInOutBack(float t) {
      const float c1 = 1.70158f;
      const float c2 = c1 * 1.525f;

      return t < 0.5f
        ? (MathF.Pow(2 * t, 2) * ((c2 + 1) * 2 * t - c2)) / 2
        : (MathF.Pow(2 * t - 2, 2) * ((c2 + 1) * (t * 2 - 2) + c2) + 2) / 2;
    }
  }

}
