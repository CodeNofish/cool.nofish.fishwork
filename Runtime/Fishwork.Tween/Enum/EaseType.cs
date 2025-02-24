namespace Fishwork.Tween {

  public enum EaseType {
    /// <summary>
    /// 线性缓动
    /// </summary>
    Linear,
    
    /// <summary>
    /// 正弦缓动 加速
    /// </summary>
    SineIn,
    
    /// <summary>
    /// 正弦缓动 减速
    /// </summary>
    SineOut,
    
    /// <summary>
    /// 正弦缓动 加速减速
    /// </summary>
    SineInOut,
 
    /// <summary>
    /// 二次缓动 加速
    /// </summary>
    QuadIn,
    
    /// <summary>
    /// 二次缓动 减速
    /// </summary>
    QuadOut,
    
    /// <summary>
    /// 二次缓动 加速减速
    /// </summary>
    QuadInOut,
    
    /// <summary>
    /// 三次缓动 加速
    /// </summary>
    CubicIn,
    
    /// <summary>
    /// 三次缓动 减速
    /// </summary>
    CubicOut,
    
    /// <summary>
    /// 三次缓动 加速减速
    /// </summary>
    CubicInOut,

    /// <summary>
    /// 四次缓动 加速
    /// </summary>
    QuartIn,
    
    /// <summary>
    /// 四次缓动 减速
    /// </summary>
    QuartOut,
    
    /// <summary>
    /// 四次缓动 加速减速
    /// </summary>
    QuartInOut,

    /// <summary>
    /// 五次缓动 加速
    /// </summary>
    QuintIn,
    
    /// <summary>
    /// 五次缓动 减速
    /// </summary>
    QuintOut,
    
    /// <summary>
    /// 五次缓动 加速减速
    /// </summary>
    QuintInOut,

    /// <summary>
    /// 指数缓动 加速
    /// </summary>
    ExpoIn,
    
    /// <summary>
    /// 指数缓动 减速
    /// </summary>
    ExpoOut,
    
    /// <summary>
    /// 指数缓动 加速减速
    /// </summary>
    ExpoInOut,

    /// <summary>
    /// 圆形缓动 加速
    /// </summary>
    CircIn,
    
    /// <summary>
    /// 圆形缓动 减速
    /// </summary>
    CircOut,
    
    /// <summary>
    /// 圆形缓动 加速减速
    /// </summary>
    CircInOut,

    /// <summary>
    /// 弹性缓动 加速
    /// </summary>
    ElasticIn,
    
    /// <summary>
    /// 弹性缓动 减速
    /// </summary>
    ElasticOut,
    
    /// <summary>
    /// 弹性缓动 加速减速
    /// </summary>
    ElasticInOut,

    /// <summary>
    /// 反向缓动 加速
    /// <para>在开始或结束时稍微超出范围，然后回弹回来，适用于具有反向惯性的动画</para>
    /// </summary>
    BackIn,
    
    /// <summary>
    /// 反向缓动 减速
    /// <para>在开始或结束时稍微超出范围，然后回弹回来，适用于具有反向惯性的动画</para>
    /// </summary>
    BackOut,
    
    /// <summary>
    /// 反向缓动 加速减速
    /// <para>在开始或结束时稍微超出范围，然后回弹回来，适用于具有反向惯性的动画</para>
    /// </summary>
    BackInOut,

    /// <summary>
    /// 回弹缓动 加速
    /// </summary>
    BounceIn,
    
    /// <summary>
    /// 回弹缓动 减速
    /// </summary>
    BounceOut,
    
    /// <summary>
    /// 回弹缓动 加速减速
    /// </summary>
    BounceInOut,
    
    /// <summary>
    /// 双曲正切缓动 加速
    /// <para>使用双曲正切函数，使缓动具有平滑的S形曲线</para>
    /// </summary>
    TangentIn,
    
    /// <summary>
    /// 双曲正切缓动 减速
    /// <para>使用双曲正切函数，使缓动具有平滑的S形曲线</para>
    /// </summary>
    TangentOut,
    
    /// <summary>
    /// 双曲正切缓动 加速减速
    /// <para>使用双曲正切函数，使缓动具有平滑的S形曲线</para>
    /// </summary>
    TangentInOut,
    
    /// <summary>
    /// 高斯缓动 加速
    /// </summary>
    GaussianIn,
    
    /// <summary>
    /// 高斯缓动 减速
    /// </summary>
    GaussianOut,
    
    /// <summary>
    /// 高斯缓动 加速减速
    /// </summary>
    GaussianInOut,
    
    /// <summary>
    /// 对数缓动 加速
    /// <para>增长缓慢，后期加速。适用于模拟现实中缓慢起步的运动，如汽车启动</para>
    /// </summary>
    LogarithmicIn,
    
    /// <summary>
    /// 对数缓动 减速
    /// <para>增长缓慢，后期加速。适用于模拟现实中缓慢起步的运动，如汽车启动</para>
    /// </summary>
    LogarithmicOut,
    
    /// <summary>
    /// 对数缓动 加速减速
    /// <para>增长缓慢，后期加速。适用于模拟现实中缓慢起步的运动，如汽车启动</para>
    /// </summary>
    LogarithmicInOut,
    
    /// <summary>
    /// Sigmoid缓动
    /// <para>类似S形曲线，常用于平滑的UI过渡效果</para>
    /// </summary>
    Sigmoid,
    
    /// <summary>
    /// 反正弦缓动
    /// <para>用于特定的非线性插值，可以提供独特的视觉效果</para>
    /// </summary>
    Arcsin,
    
    /// <summary>
    /// 抛物线缓动
    /// <para>提供一个类似自由落体运动的缓动效果</para>
    /// </summary>
    Parabolic,
    
    /// <summary>
    /// 指数回弹缓动
    /// <para>类似弹性缓动，但更快速的收敛回到目标值</para>
    /// </summary>
    ExponentialBounce,

    AnimationCurve
  }

}
