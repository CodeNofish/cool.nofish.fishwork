using System;

namespace Fishwork.Tween {

  // ReSharper disable once CompareOfFloatsByEqualityOperator
  public static partial class EasingFunction {
    public static float EaseInElastic(float t) {
      const float c4 = 2 * MathF.PI / 3;

      return t == 0
        ? 0
        : t == 1
          ? 1
          : -MathF.Pow(2, 10 * t - 10) * MathF.Sin((t * 10 - 10.75f) * c4);
    }

    public static float EaseOutElastic(float t) {
      const float c4 = 2 * MathF.PI / 3;

      return t == 0
        ? 0
        : t == 1
          ? 1
          : MathF.Pow(2, -10 * t) * MathF.Sin((t * 10 - 0.75f) * c4) + 1;
    }

    public static float EaseInOutElastic(float t) {
      const float c5 = 2 * MathF.PI / 4.5f;

      return t == 0
        ? 0
        : t == 1
          ? 1
          : t < 0.5
            ? -(MathF.Pow(2, 20 * t - 10) * MathF.Sin((20 * t - 11.125f) * c5)) / 2
            : (MathF.Pow(2, -20 * t + 10) * MathF.Sin((20 * t - 11.125f) * c5)) / 2 + 1;
    }
  }

}
