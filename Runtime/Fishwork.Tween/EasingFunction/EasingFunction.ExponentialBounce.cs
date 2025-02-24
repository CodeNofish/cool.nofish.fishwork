using System;

namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseExponentialBounce(float t) {
      return 1 - MathF.Pow(2, -10 * t) * MathF.Cos(20 * MathF.PI * t);
    }
  }

}
