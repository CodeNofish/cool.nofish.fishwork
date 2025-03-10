﻿namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseInBounce(float t) {
      return 1 - EaseOutBounce(1 - t);
    }

    public static float EaseOutBounce(float t) {
      const float n1 = 7.5625f;
      const float d1 = 2.75f;
      
      if (t < 1 / d1)
        return n1 * t * t;
      if (t < 2f / d1)
        return n1 * (t -= 1.5f / d1) * t + 0.75f;
      if (t < 2.5f / d1)
        return n1 * (t -= 2.25f / d1) * t + 0.9375f;
      return n1 * (t -= 2.625f / d1) * t + 0.984375f;
    }

    public static float EaseInOutBounce(float t) {
      return t < 0.5f
        ? (1 - EaseOutBounce(1 - 2 * t)) / 2
        : (1 + EaseOutBounce(2 * t - 1)) / 2;
    }
  }

}
