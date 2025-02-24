using System;

namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseSigmoid(float t) {
      return 1 / (1 + MathF.Exp(-10 * (t - 0.5f)));
    }
  }

}
