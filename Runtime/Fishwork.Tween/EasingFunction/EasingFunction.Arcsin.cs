using System;

namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseArcsin(float t) {
      return MathF.Asin(2 * t - 1) / MathF.PI + 0.5f;
    }
  }

}
