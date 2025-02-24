using System;

namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseInSine(float t) {
      return 1 - MathF.Cos(t * MathF.PI / 2);
    }

    public static float EaseOutSine(float t) {
      return MathF.Sin(t * MathF.PI / 2);
    }

    public static float EaseInOutSine(float t) {
      return -(MathF.Cos(MathF.PI * t) - 1) / 2;
    }
  }

}
