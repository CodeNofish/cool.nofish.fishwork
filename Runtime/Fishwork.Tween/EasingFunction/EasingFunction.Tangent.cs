using System;

namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseInTanh(float t) {
      return MathF.Tanh(3 * (t - 1)) + 1;
    }

    public static float EaseOutTanh(float t) {
      return MathF.Tanh(3 * t);
    }

    public static float EaseInOutTanh(float t) {
      return (MathF.Tanh(6 * (t - 0.5f)) + 1) / 2;
    }
  }

}
