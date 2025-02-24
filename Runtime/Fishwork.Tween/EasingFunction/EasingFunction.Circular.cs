using System;

namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseInCirc(float t) {
      return 1 - MathF.Sqrt(1 - t * t);
    }

    public static float EaseOutCirc(float t) {
      return MathF.Sqrt(1 - MathF.Pow(t - 1, 2));
    }

    public static float EaseInOutCirc(float t) {
      return t < 0.5f
        ? (1 - MathF.Sqrt(1 - 4 * t * t)) / 2
        : (MathF.Sqrt(1 - 4 * (t - 1) * (t - 1)) + 1) / 2;
    }
  }

}
