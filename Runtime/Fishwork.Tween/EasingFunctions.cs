using System;

namespace Fishwork.Tween {

  /// <summary>
  /// 缓动函数实现
  /// </summary>
  public static class EasingFunctions {
    #region 线性缓动
    public static float Linear(float t) {
      return t;
    }
    #endregion

    #region 二次缓动
    public static float EaseInQuad(float t) {
      return t * t;
    }

    public static float EaseOutQuad(float t) {
      return t * (2 - t);
    }

    public static float EaseInOutQuad(float t) {
      return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
    }
    #endregion

    #region 三次缓动
    public static float EaseInCubic(float t) {
      return t * t * t;
    }

    public static float EaseOutCubic(float t) {
      return (--t) * t * t + 1;
    }

    public static float EaseInOutCubic(float t) {
      return t < 0.5f ? 4 * t * t * t : (t - 1) * (2 * t - 2) * (2 * t - 2) + 1;
    }
    #endregion

    #region 四次缓动
    public static float EaseInQuart(float t) {
      return t * t * t * t;
    }

    public static float EaseOutQuart(float t) {
      return 1 - (--t) * t * t * t;
    }

    public static float EaseInOutQuart(float t) {
      return t < 0.5f ? 8 * t * t * t * t : 1 - 8 * (--t) * t * t * t;
    }
    #endregion

    #region 五次缓动
    public static float EaseInQuint(float t) {
      return t * t * t * t * t;
    }

    public static float EaseOutQuint(float t) {
      return 1 + (--t) * t * t * t * t;
    }

    public static float EaseInOutQuint(float t) {
      return t < 0.5f ? 16 * t * t * t * t * t : 1 + 16 * (--t) * t * t * t * t;
    }
    #endregion

    #region 正弦缓动
    public static float EaseInSine(float t) {
      return 1 - MathF.Cos(t * MathF.PI / 2);
    }

    public static float EaseOutSine(float t) {
      return MathF.Sin(t * MathF.PI / 2);
    }

    public static float EaseInOutSine(float t) {
      return -(MathF.Cos(MathF.PI * t) - 1) / 2;
    }
    #endregion

    #region 指数缓动
    public static float EaseInExpo(float t) {
      return t == 0 ? 0 : MathF.Pow(2, 10 * (t - 1));
    }

    public static float EaseOutExpo(float t) {
      return t == 1 ? 1 : 1 - MathF.Pow(2, -10 * t);
    }

    public static float EaseInOutExpo(float t) {
      if (t == 0) return 0;
      if (t == 1) return 1;
      if ((t *= 2) < 1) return 0.5f * MathF.Pow(2, 10 * (t - 1));
      return 0.5f * (-MathF.Pow(2, -10 * --t) + 2);
    }
    #endregion

    #region 圆形缓动
    public static float EaseInCirc(float t) {
      return 1 - MathF.Sqrt(1 - t * t);
    }

    public static float EaseOutCirc(float t) {
      return MathF.Sqrt(1 - (--t) * t);
    }

    public static float EaseInOutCirc(float t) {
      return t < 0.5f
        ? (1 - MathF.Sqrt(1 - 4 * t * t)) / 2
        : (MathF.Sqrt(1 - 4 * (t - 1) * (t - 1)) + 1) / 2;
    }
    #endregion

    #region 弹性缓动
    public static float EaseInElastic(float t) {
      if (t == 0) return 0;
      if (t == 1) return 1;
      return -MathF.Pow(2, 10 * (t - 1)) * MathF.Sin((t - 1.1f) * 5 * MathF.PI);
    }

    public static float EaseOutElastic(float t) {
      if (t == 0) return 0;
      if (t == 1) return 1;
      return MathF.Pow(2, -10 * t) * MathF.Sin((t - 0.1f) * 5 * MathF.PI) + 1;
    }

    public static float EaseInOutElastic(float t) {
      if (t == 0) return 0;
      if (t == 1) return 1;
      t *= 2;
      if (t < 1) return -0.5f * MathF.Pow(2, 10 * (t - 1)) * MathF.Sin((t - 1.1f) * 5 * MathF.PI);
      return 0.5f * MathF.Pow(2, -10 * (t - 1)) * MathF.Sin((t - 1.1f) * 5 * MathF.PI) + 1;
    }
    #endregion

    #region 反弹缓动
    public static float EaseInBounce(float t) {
      return 1 - EaseOutBounce(1 - t);
    }

    public static float EaseOutBounce(float t) {
      if (t < 1 / 2.75f) {
        return 7.5625f * t * t;
      }
      if (t < 2 / 2.75f) {
        t -= 1.5f / 2.75f;
        return 7.5625f * t * t + 0.75f;
      }
      if (t < 2.5f / 2.75f) {
        t -= 2.25f / 2.75f;
        return 7.5625f * t * t + 0.9375f;
      }
      t -= 2.625f / 2.75f;
      return 7.5625f * t * t + 0.984375f;
    }

    public static float EaseInOutBounce(float t) {
      return t < 0.5f
        ? (1 - EaseOutBounce(1 - 2 * t)) / 2
        : (1 + EaseOutBounce(2 * t - 1)) / 2;
    }
    #endregion

    #region 反向缓动 反向缓动会在动画的开始或结束时产生一个“回拉”效果。
    public static float EaseInBack(float t) {
      float s = 1.70158f;
      return t * t * ((s + 1) * t - s);
    }

    public static float EaseOutBack(float t) {
      float s = 1.70158f;
      return (t -= 1) * t * ((s + 1) * t + s) + 1;
    }

    public static float EaseInOutBack(float t) {
      float s = 1.70158f * 1.525f;
      if ((t *= 2) < 1)
        return 0.5f * (t * t * ((s + 1) * t - s));
      return 0.5f * ((t -= 2) * t * ((s + 1) * t + s) + 2);
    }
    #endregion

    #region 弹性增强缓动 弹性缓动的增强版本，允许自定义弹性参数。
    public static float EaseInEnhancedElastic(float t, float amplitude = 1, float period = 0.3f) {
      if (t == 0) return 0;
      if (t == 1) return 1;
      float s = period / 4;
      t -= 1;
      return -(amplitude * MathF.Pow(2, 10 * t) * MathF.Sin((t - s) * (2 * MathF.PI) / period));
    }

    public static float EaseOutEnhancedElastic(float t, float amplitude = 1, float period = 0.3f) {
      if (t == 0) return 0;
      if (t == 1) return 1;
      float s = period / 4;
      return amplitude * MathF.Pow(2, -10 * t) * MathF.Sin((t - s) * (2 * MathF.PI) / period) + 1;
    }

    public static float EaseInOutEnhancedElastic(float t, float amplitude = 1, float period = 0.3f) {
      if (t == 0) return 0;
      if (t == 1) return 1;
      float s = period / 4;
      t *= 2;
      if (t < 1)
        return -0.5f * (amplitude * MathF.Pow(2, 10 * (t - 1)) * MathF.Sin((t - 1 - s) * (2 * MathF.PI) / period));
      return amplitude * MathF.Pow(2, -10 * (t - 1)) * MathF.Sin((t - 1 - s) * (2 * MathF.PI) / period) * 0.5f + 1;
    }
    #endregion

    #region 阶梯缓动 阶梯缓动将动画分为固定的步数，而不是平滑过渡。
    public static float EaseSteps(float t, int steps = 5, bool jumpAtEnd = false) {
      if (jumpAtEnd)
        return MathF.Floor(t * steps) / steps;
      else
        return MathF.Ceiling(t * steps) / steps;
    }
    #endregion

    #region 平滑阶梯缓动 在阶梯之间添加平滑过渡。
    public static float EaseSmoothStep(float t) {
      return t * t * (3 - 2 * t);
    }

    public static float EaseSmootherStep(float t) {
      return t * t * t * (t * (6 * t - 15) + 10);
    }
    #endregion

    #region 自定义贝塞尔缓动 贝塞尔缓动允许通过控制点自定义缓动曲线。
    public static float EaseBezier(float t, float p0, float p1, float p2, float p3) {
      float u = 1 - t;
      float tt = t * t;
      float uu = u * u;
      float uuu = uu * u;
      float ttt = tt * t;

      float result = uuu * p0; // (1-t)^3 * p0
      result += 3 * uu * t * p1; // 3(1-t)^2 * t * p1
      result += 3 * u * tt * p2; // 3(1-t) * t^2 * p2
      result += ttt * p3; // t^3 * p3

      return result;
    }
    #endregion

    #region 自定义幂函数缓动 幂函数缓动允许自定义幂次
    public static float EaseInPower(float t, float power = 2) {
      return MathF.Pow(t, power);
    }

    public static float EaseOutPower(float t, float power = 2) {
      return 1 - MathF.Pow(1 - t, power);
    }

    public static float EaseInOutPower(float t, float power = 2) {
      if (t < 0.5f)
        return MathF.Pow(t * 2, power) / 2;
      else
        return 1 - MathF.Pow(2 - t * 2, power) / 2;
    }
    #endregion

    #region 自定义混合缓动 混合缓动允许将两种缓动函数结合起来。
    public static float EaseBlend(float t, Func<float, float> ease1, Func<float, float> ease2, float blend = 0.5f) {
      return ease1(t) * (1 - blend) + ease2(t) * blend;
    }
    #endregion

    #region 自定义分段缓动 分段缓动允许在不同的区间使用不同的缓动函数。
    public static float EasePiecewise(float t, Func<float, float> ease1, Func<float, float> ease2, float split = 0.5f) {
      if (t < split)
        return ease1(t / split) * split;
      else
        return ease2((t - split) / (1 - split)) * (1 - split) + split;
    }
    #endregion

    #region 自定义随机缓动 随机缓动在动画中添加随机性。
    public static float EaseRandom(float t, float min = 0, float max = 1) {
      Random rand = new Random();
      return t + (float)(rand.NextDouble() * (max - min) + min);
    }
    #endregion

    #region 自定义阻尼缓动 阻尼缓动模拟物理阻尼效果。
    public static float EaseDamped(float t, float damping = 0.5f) {
      return 1 - MathF.Exp(-damping * t) * MathF.Cos(t * MathF.PI * 2);
    }
    #endregion

    #region 指数衰减缓动 模拟指数衰减效果，常用于物理模拟。
    public static float EaseExponentialDecay(float t, float decayFactor = 1) {
      return 1 - MathF.Exp(-decayFactor * t);
    }
    #endregion

    #region 对数缓动 对数缓动可以创建快速开始、缓慢结束的效果。
    public static float EaseInLog(float t) {
      return MathF.Log10(t * 9 + 1);
    }

    public static float EaseOutLog(float t) {
      return 1 - MathF.Log10(10 - t * 9);
    }

    public static float EaseInOutLog(float t) {
      if (t < 0.5f)
        return MathF.Log10(t * 18 + 1) / 2;
      else
        return 1 - MathF.Log10(20 - t * 18) / 2;
    }
    #endregion

    #region 双曲线缓动 双曲线缓动可以创建非常平滑的过渡效果。
    public static float EaseInHyperbolic(float t) {
      return 1 / (1 - t);
    }

    public static float EaseOutHyperbolic(float t) {
      return t / (1 + t);
    }

    public static float EaseInOutHyperbolic(float t) {
      if (t < 0.5f)
        return 0.5f / (1 - 2 * t);
      else
        return (2 * t - 1) / (2 * t);
    }
    #endregion

    #region 抛物线缓动 抛物线缓动模拟抛物线运动。
    public static float EaseInParabola(float t) {
      return t * t;
    }

    public static float EaseOutParabola(float t) {
      return t * (2 - t);
    }

    public static float EaseInOutParabola(float t) {
      return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
    }
    #endregion

    #region 自定义分段线性缓动 分段线性缓动允许定义多个关键点。
    public static float EasePiecewiseLinear(float t, float[] keys) {
      if (keys == null || keys.Length == 0)
        throw new ArgumentException("Keys array must not be empty.");

      int index = (int)(t * (keys.Length - 1));
      float t0 = (float)index / (keys.Length - 1);
      float t1 = (float)(index + 1) / (keys.Length - 1);
      float value0 = keys[index];
      float value1 = keys[index + 1];

      return value0 + (value1 - value0) * (t - t0) / (t1 - t0);
    }
    #endregion

    #region 自定义分段贝塞尔缓动 分段贝塞尔缓动允许在多个区间使用不同的贝塞尔曲线。
    public static float EasePiecewiseBezier(float t, (float p0, float p1, float p2, float p3)[] segments) {
      if (segments == null || segments.Length == 0)
        throw new ArgumentException("Segments array must not be empty.");

      int index = (int)(t * segments.Length);
      float t0 = (float)index / segments.Length;
      float t1 = (float)(index + 1) / segments.Length;
      var segment = segments[index];
      float normalizedT = (t - t0) / (t1 - t0);

      return EaseBezier(normalizedT, segment.p0, segment.p1, segment.p2, segment.p3);
    }
    #endregion
  }

}
