using System;

namespace Fishwork.Tween {

  // ReSharper disable once CompareOfFloatsByEqualityOperator
  public static partial class EasingFunction {
    public static float EaseInExpo(float t) {
      return t == 0 ? 0 : MathF.Pow(2, 10 * t - 10);
    }

    public static float EaseOutExpo(float t) {
      return t == 1 ? 1 : 1 - MathF.Pow(2, -10 * t);
    }

    public static float EaseInOutExpo(float t) {
      return t == 0
        ? 0
        : t == 1
          ? 1
          : t < 0.5
            ? MathF.Pow(2, 20 * t - 10) / 2
            : (2 - MathF.Pow(2, -20 * t + 10)) / 2;
    }
  }

}
