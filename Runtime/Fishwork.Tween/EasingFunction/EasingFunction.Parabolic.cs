namespace Fishwork.Tween {

  public static partial class EasingFunction {
    public static float EaseParabolic(float t) {
      return 4 * t * (1 - t);
    }
  }

}
