using UnityEngine;

namespace Fishwork.Core {

  public static class RectExtension {
    /// <summary>
    /// 沿中心扩展 
    /// </summary>
    public static Rect Expand(this Rect rect, float value) {
      rect.xMin -= value;
      rect.xMax += value;
      rect.yMin -= value;
      rect.yMax += value;
      return rect;
    }
    
    /// <summary>
    /// 沿中心 横向扩展
    /// </summary>
    public static Rect ExpandX(this Rect rect, float value) {
      rect.xMin -= value;
      rect.xMax += value;
      return rect;
    }

    /// <summary>
    /// 沿中心 纵向扩展
    /// </summary>
    public static Rect ExpandY(this Rect rect, float value) {
      rect.yMin -= value;
      rect.yMax += value;
      return rect;
    }
    
    /// <summary>
    /// 纵向移动锚点(左上角位置)
    /// </summary>
    public static Rect AddX(this Rect rect, float value) {
      rect.x += value;
      return rect;
    }

    /// <summary>
    /// 纵向移动锚点(左上角位置)
    /// </summary>
    public static Rect AddY(this Rect rect, float value) {
      rect.y += value;
      return rect;
    }
    
    /// <summary>
    /// 移动矩形左边界
    /// </summary>
    public static Rect AddXMin(this Rect rect, float value) {
      rect.xMin += value;
      return rect;
    }

    /// <summary>
    /// 移动矩形右边界
    /// </summary>
    public static Rect AddXMax(this Rect rect, float value) {
      rect.xMax += value;
      return rect;
    }

    /// <summary>
    /// 移动矩形上边界
    /// </summary>
    public static Rect AddYMin(this Rect rect, float value) {
      rect.yMin += value;
      return rect;
    }

    /// <summary>
    /// 移动矩形下边界
    /// </summary>
    public static Rect AddYMax(this Rect rect, float value) {
      rect.yMax += value;
      return rect;
    }

    /// <summary>
    /// 设置矩形的宽度
    /// </summary>
    public static Rect SetWidth(this Rect rect, float value) {
      rect.width = value;
      return rect;
    }

    /// <summary>
    /// 设置矩形的高度
    /// </summary>
    public static Rect SetHeight(this Rect rect, float value) {
      rect.height = value;
      return rect;
    }
  }

}
