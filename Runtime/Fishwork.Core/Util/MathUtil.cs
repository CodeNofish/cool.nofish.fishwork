using System;

namespace Fishwork.Core {
  
  public static class MathUtil {
    public const double Epsilon = 2.2204460492503131E-16;
    public const double EpsilonSquared = Epsilon * Epsilon;
    
    /// <summary>
    /// 比较两个双精度浮点数是否近似相等（相对误差近似为零）
    /// </summary>
    public static bool ApproxEquals(double d1, double d2) {
      // ReSharper disable once CompareOfFloatsByEqualityOperator
      if (d1 == d2) return true;
      double tolerance = (Math.Abs(d1) + Math.Abs(d2) + 10.0) * Epsilon;
      double difference = d1 - d2;
      return -tolerance < difference && tolerance > difference;
    }
  }

}
