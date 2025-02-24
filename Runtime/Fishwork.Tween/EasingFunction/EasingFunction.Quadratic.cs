namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseInQuad(float t) {
      return t * t;
    }

    public static float EaseOutQuad(float t) {
      return t * (2 - t);
    }

    public static float EaseInOutQuad(float t) {
      return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
    }
  }

}
