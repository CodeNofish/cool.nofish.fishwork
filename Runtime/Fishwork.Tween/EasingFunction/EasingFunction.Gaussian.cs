using System;

namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseInGaussian(float t) {
      return 1 - MathF.Exp(-5 * t * t);
    }

    public static float EaseOutGaussian(float t) {
      return MathF.Exp(-5 * (t - 1) * (t - 1));
    }

    public static float EaseInOutGaussian(float t) {
      return (1 - MathF.Exp(-10 * (t - 0.5f) * (t - 0.5f))) / (1 - MathF.Exp(-2.5f));
    }
  }

}
