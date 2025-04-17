using System;
using UnityEditor;
using UnityEngine;

namespace Fishwork.Core.Editor {

  /// <summary>
  /// Unity Editor Foundations 调色板。
  /// <see cref="www.foundations.unity.com/fundamentals/color-palette"/>
  /// </summary>
  public class FoundationColorPalette {
    private static Color GetColor(string htmlColor) {
      if (!ColorUtility.TryParseHtmlString(htmlColor, out var color)) throw new ArgumentException();
      return color;
    }

    /// <summary>
    /// UI状态伪类
    /// </summary>
    public enum PseudoState {
      Normal,
      Checked,
      Disabled,
      Focus,
      Hover,
      Inactive,
      Pressed,
      Selected,

      // Accent 样式通常会应用在 Hover Pressed Selected 状态中，以增强视觉效果。
    }

    #region ApplicationBar 应用工具栏
    /// <summary>
    /// 应用工具栏背景
    /// </summary>
    public static Color AppToolbarBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#191919");
        return GetColor("#8A8A8A");
      }
    }

    /// <summary>
    /// 应用工具栏按钮背景
    /// </summary>
    public static Color AppToolbarButtonBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#383838");
        return GetColor("#C8C8C8");
      }
    }

    /// <summary>
    /// 应用工具栏按钮背景 Checked
    /// </summary>
    public static Color AppToolbarButtonBackgroundChecked {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#6A6A6A");
        return GetColor("#656565");
      }
    }

    /// <summary>
    /// 应用工具栏按钮背景 Hover
    /// </summary>
    public static Color AppToolbarButtonBackgroundHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#424242");
        return GetColor("#BBBBBB");
      }
    }

    /// <summary>
    /// 应用工具栏按钮背景 Pressed
    /// </summary>
    public static Color AppToolbarButtonBackgroundPressed {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#6A6A6A");
        return GetColor("#656565");
      }
    }

    /// <summary>
    /// 应用工具栏按钮边框
    /// </summary>
    public static Color AppToolbarButtonBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#191919");
        return GetColor("#6B6B6B");
      }
    }

    /// <summary>
    /// 应用工具栏按钮边框 Pressed
    /// </summary>
    public static Color AppToolbarButtonBorderAccent {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#222222");
        return GetColor("#6B6B6B");
      }
    }
    #endregion

    #region Button 按钮
    /// <summary>
    /// 按钮背景
    /// </summary>
    public static Color ButtonBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#585858");
        return GetColor("#E4E4E4");
      }
    }

    /// <summary>
    /// 按钮背景 Focus
    /// </summary>
    public static Color ButtonBackgroundFocus {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#6E6E6E");
        return GetColor("#BEBEBE");
      }
    }

    /// <summary>
    /// 按钮背景 Hover
    /// </summary>
    public static Color ButtonBackgroundHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#676767");
        return GetColor("#ECECEC");
      }
    }

    /// <summary>
    /// 按钮背景 HoverPressed
    /// </summary>
    public static Color ButtonBackgroundHoverPressed {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#4F657F");
        return GetColor("#B0D2FC");
      }
    }

    /// <summary>
    /// 按钮背景 Pressed
    /// </summary>
    public static Color ButtonBackgroundPressed {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#46607C");
        return GetColor("#96C3FB");
      }
    }

    /// <summary>
    /// 按钮边框
    /// </summary>
    public static Color ButtonBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#303030");
        return GetColor("#B2B2B2");
      }
    }

    /// <summary>
    /// 按钮边框 Accent
    /// </summary>
    public static Color ButtonBorderAccent {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#242424");
        return GetColor("#939393");
      }
    }

    /// <summary>
    /// 按钮边框 AccentFocus
    /// </summary>
    public static Color ButtonBorderAccentFocus {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#7BAEFA");
        return GetColor("#018CFF");
      }
    }

    /// <summary>
    /// 按钮边框 Pressed
    /// </summary>
    public static Color ButtonBorderPressed {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#0D0D0D");
        return GetColor("#707070");
      }
    }

    /// <summary>
    /// 按钮文字
    /// </summary>
    public static Color ButtonText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#EEEEEE");
        return GetColor("#090909");
      }
    }
    #endregion

    #region HelpBox 帮助框
    /// <summary>
    /// 帮助框背景
    /// </summary>
    public static Color HelpboxBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return new Color(96, 96, 96, 0.2039216f);
        return new Color(235, 235, 235, 0.2039216f);
      }
    }

    /// <summary>
    /// 帮助框边框
    /// </summary>
    public static Color HelpboxBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#232323");
        return GetColor("#A9A9A9");
      }
    }

    /// <summary>
    /// 帮助框文本
    /// </summary>
    public static Color HelpboxText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#BDBDBD");
        return GetColor("#161616");
      }
    }
    #endregion

    #region InputField 输入字段
    /// <summary>
    /// 输入字段背景
    /// </summary>
    public static Color InputFieldBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#2A2A2A");
        return GetColor("#F0F0F0");
      }
    }

    /// <summary>
    /// 输入字段边框
    /// </summary>
    public static Color InputFieldBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#212121");
        return GetColor("#B7B7B7");
      }
    }

    /// <summary>
    /// 输入字段边框 Accent
    /// </summary>
    public static Color InputFieldBorderAccent {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#0D0D0D");
        return GetColor("#A0A0A0");
      }
    }

    /// <summary>
    /// 输入字段边框 Focus
    /// </summary>
    public static Color InputFieldBorderFocus {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#3A79BB");
        return GetColor("#1D5087");
      }
    }

    /// <summary>
    /// 输入字段边框 Hover
    /// </summary>
    public static Color InputFieldBorderHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#656565");
        return GetColor("#6C6C6C");
      }
    }
    #endregion

    #region MultiColumnHeader 多列标题
    /// <summary>
    /// 标题栏背景
    /// </summary>
    public static Color HeaderBarBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#3C3C3C");
        return GetColor("#CBCBCB");
      }
    }

    /// <summary>
    /// 标题栏中用于列控件的背景颜色
    /// </summary>
    public static Color HeaderBarColumnControlBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#3C3C3C");
        return GetColor("#CBCBCB");
      }
    }

    /// <summary>
    /// 标题栏中用于列控件的背景颜色 Hover
    /// </summary>
    public static Color HeaderBarColumnControlBackgroundHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#464646");
        return GetColor("#C1C1C1");
      }
    }

    /// <summary>
    /// 标题栏中用于列控件的背景颜色 Pressed
    /// </summary>
    public static Color HeaderBarColumnControlBackgroundPressed {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#505050");
        return GetColor("#EFEFEF");
      }
    }
    #endregion

    #region ObjectField 对象字段
    /// <summary>
    /// 对象字段背景
    /// </summary>
    public static Color ObjectFieldBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#282828");
        return GetColor("#EDEDED");
      }
    }

    /// <summary>
    /// 对象字段边框
    /// </summary>
    public static Color ObjectFieldBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#202020");
        return GetColor("#B0B0B0");
      }
    }

    /// <summary>
    /// 对象字段边框 Focus
    /// </summary>
    public static Color ObjectFieldBorderFocus {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#3A79BB");
        return GetColor("#1D5087");
      }
    }

    /// <summary>
    /// 对象字段边框 Hover
    /// </summary>
    public static Color ObjectFieldBorderHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#656565");
        return GetColor("#6C6C6C");
      }
    }

    /// <summary>
    /// 对象字段按钮背景
    /// </summary>
    public static Color ObjectFieldButtonBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#373737");
        return GetColor("#DEDEDE");
      }
    }

    /// <summary>
    /// 对象字段按钮背景 Hover
    /// </summary>
    public static Color ObjectFieldButtonBackgroundHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#4C4C4C");
        return GetColor("#CCCCCC");
      }
    }
    #endregion

    #region Scrollbar 滚动栏
    /// <summary>
    /// 滚动栏按钮背景
    /// </summary>
    public static Color ScrollbarButtonBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return new Color(0, 0, 0, 0.05098039f);
        return new Color(0, 0, 0, 0.05098039f);
      }
    }

    /// <summary>
    /// 滚动栏按钮背景 Hover
    /// </summary>
    public static Color ScrollbarButtonBackgroundHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#494949");
        return GetColor("#A7A7A7");
      }
    }

    /// <summary>
    /// 滚动栏凹槽背景
    /// </summary>
    public static Color ScrollbarGrooveBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return new Color(0, 0, 0, 0.05098039f);
        return new Color(0, 0, 0, 0.05098039f);
      }
    }

    /// <summary>
    /// 滚动栏凹槽边界
    /// </summary>
    public static Color ScrollbarGrooveBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return new Color(0, 0, 0, 0.1019608f);
        return new Color(0, 0, 0, 0.1019608f);
      }
    }

    /// <summary>
    /// 滚动栏手柄背景
    /// </summary>
    public static Color ScrollbarThumbBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#5F5F5F");
        return GetColor("#9A9A9A");
      }
    }

    /// <summary>
    /// 滚动栏手柄背景 Hover
    /// </summary>
    public static Color ScrollbarThumbBackgroundHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#686868");
        return GetColor("#8E8E8E");
      }
    }

    /// <summary>
    /// 滚动栏手柄边框
    /// </summary>
    public static Color ScrollbarThumbBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#323232");
        return GetColor("#B9B9B9");
      }
    }

    /// <summary>
    /// 滚动栏手柄边框 Hover
    /// </summary>
    public static Color ScrollbarThumbBorderHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#686868");
        return GetColor("#8E8E8E");
      }
    }
    #endregion

    #region Slider 滑块
    /// <summary>
    /// 滑块凹槽背景
    /// </summary>
    public static Color SliderGrooveBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#5E5E5E");
        return GetColor("#8F8F8F");
      }
    }

    /// <summary>
    /// 滑块凹槽背景 Disabled
    /// </summary>
    public static Color SliderGrooveBackgroundDisabled {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#575757");
        return GetColor("#A4A4A4");
      }
    }

    /// <summary>
    /// 滑块手柄背景
    /// </summary>
    public static Color SliderThumbBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#999999");
        return GetColor("#616161");
      }
    }

    /// <summary>
    /// 滑块手柄背景 Disabled
    /// </summary>
    public static Color SliderThumbBackgroundDisabled {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#666666");
        return GetColor("#9B9B9B");
      }
    }

    /// <summary>
    /// 滑块手柄背景 Hover
    /// </summary>
    public static Color SliderThumbBackgroundHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#EAEAEA");
        return GetColor("#4F4F4F");
      }
    }

    /// <summary>
    /// 滑块手柄边框
    /// </summary>
    public static Color SliderThumbBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#999999");
        return GetColor("#616161");
      }
    }

    /// <summary>
    /// 滑块手柄边框 Disabled
    /// </summary>
    public static Color SliderThumbBorderDisabled {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#666666");
        return GetColor("#666666");
      }
    }

    /// <summary>
    /// 滑块手柄光晕背景
    /// </summary>
    public static Color SliderThumbHaloBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return new Color(16, 111, 205, 0.5019608f);
        return new Color(12, 108, 203, 0.5019608f);
      }
    }
    #endregion

    #region Tab 编辑器窗口选项卡
    /// <summary>
    /// 编辑器窗口选项卡背景
    /// </summary>
    public static Color TabBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#353535");
        return GetColor("#B6B6B6");
      }
    }

    /// <summary>
    /// 编辑器窗口选项卡背景 Checked
    /// </summary>
    public static Color TabBackgroundChecked {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#3C3C3C");
        return GetColor("#CBCBCB");
      }
    }

    /// <summary>
    /// 编辑器窗口选项卡背景 Hover
    /// </summary>
    public static Color TabBackgroundHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#303030");
        return GetColor("#B0B0B0");
      }
    }

    /// <summary>
    /// 突出显示背景
    /// </summary>
    public static Color TabHighlightBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#2C5D87");
        return GetColor("#3A72B0");
      }
    }
    #endregion

    #region InspectorBackgrounds 监视器背景
    /// <summary>
    /// 在检查员视图中的标题栏的背景颜色
    /// </summary>
    public static Color InspectorTitlebarBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#3E3E3E");
        return GetColor("#CBCBCB");
      }
    }

    /// <summary>
    /// 在检查员视图中的标题栏的背景颜色 Hover
    /// </summary>
    public static Color InspectorTitlebarBackgroundHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#474747");
        return GetColor("#D6D6D6");
      }
    }

    /// <summary>
    /// Inspector 工具栏背景
    /// </summary>
    public static Color InspectorToolbarBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#3C3C3C");
        return GetColor("#CBCBCB");
      }
    }

    /// <summary>
    /// Inspector 窗口背景
    /// </summary>
    public static Color InspectorWindowBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#383838");
        return GetColor("#C8C8C8");
      }
    }
    #endregion

    #region InspectorBorders 监视器边界
    /// <summary>
    /// 在监视器视图中的标题栏的边框颜色
    /// </summary>
    public static Color InspectorTitlebarBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#1A1A1A");
        return GetColor("#7F7F7F");
      }
    }

    /// <summary>
    /// 在监视器视图中的标题栏的边框颜色 Accent
    /// </summary>
    public static Color InspectorTitlebarBorderAccent {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#303030");
        return GetColor("#BABABA");
      }
    }
    #endregion

    #region WindowBackgrounds 窗口背景
    /// <summary>
    /// 控件的默认背景颜色
    /// </summary>
    public static Color WindowDefaultBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#282828");
        return GetColor("#A5A5A5");
      }
    }

    /// <summary>
    /// 控件的默认背景颜色 Inactive
    /// </summary>
    public static Color WindowDefaultBackgroundInactive {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#4D4D4D");
        return GetColor("#AEAEAE");
      }
    }

    /// <summary>
    /// 选定项目或选定文本的背景颜色
    /// </summary>
    public static Color WindowHighlightBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#2C5D87");
        return GetColor("#3A72B0");
      }
    }

    /// <summary>
    /// 选定项目或选定文本的背景颜色 Hover
    /// </summary>
    public static Color WindowHighlightBackgroundHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return new Color(256, 256, 256, 0.0627451f);
        return new Color(0, 0, 0, 0.0627451f);
      }
    }

    /// <summary>
    /// 选定项目或选定文本的背景颜色 Hover Lighter
    /// </summary>
    public static Color WindowHighlightBackgroundHoverLighter {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#5F5F5F");
        return GetColor("#9A9A9A");
      }
    }

    /// <summary>
    /// 窗口背景
    /// </summary>
    public static Color WindowBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#383838");
        return GetColor("#C8C8C8");
      }
    }

    /// <summary>
    /// 带有交替行颜色的视图的替代背景颜色
    /// </summary>
    public static Color WindowAlternatedRowsBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#3F3F3F");
        return GetColor("#CACACA");
      }
    }
    #endregion

    #region WindowBorders 窗口边界
    /// <summary>
    /// 控件的默认边框颜色
    /// </summary>
    public static Color WindowDefaultBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#232323");
        return GetColor("#999999");
      }
    }

    /// <summary>
    /// 工具栏控件的边框颜色
    /// </summary>
    public static Color WindowToolbarBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#232323");
        return GetColor("#999999");
      }
    }

    /// <summary>
    /// 窗口的边框颜色
    /// </summary>
    public static Color WindowBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#242424");
        return GetColor("#939393");
      }
    }
    #endregion

    #region Toolbars 工具栏
    /// <summary>
    /// 工具栏控件的背景颜色
    /// </summary>
    public static Color ToolbarBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#3C3C3C");
        return GetColor("#CBCBCB");
      }
    }

    /// <summary>
    /// 工具栏控件的边框颜色
    /// </summary>
    public static Color ToolbarBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#232323");
        return GetColor("#999999");
      }
    }

    /// <summary>
    /// 工具栏按钮控制的背景颜色
    /// </summary>
    public static Color ToolbarButtonBackground {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#3C3C3C");
        return GetColor("#CBCBCB");
      }
    }

    /// <summary>
    /// 工具栏按钮控制的背景颜色 Checked
    /// </summary>
    public static Color ToolbarButtonBackgroundChecked {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#505050");
        return GetColor("#EFEFEF");
      }
    }

    /// <summary>
    /// 工具栏按钮控制的背景颜色 Focus
    /// </summary>
    public static Color ToolbarButtonBackgroundFocus {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#464646");
        return GetColor("#C1C1C1");
      }
    }

    /// <summary>
    /// 工具栏按钮控制的背景颜色 Hover
    /// </summary>
    public static Color ToolbarButtonBackgroundHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#464646");
        return GetColor("#C1C1C1");
      }
    }

    /// <summary>
    /// 工具栏按钮控制的边框颜色
    /// </summary>
    public static Color ToolbarButtonBorder {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#232323");
        return GetColor("#999999");
      }
    }
    #endregion

    #region DefaultTextColors 默认文本颜色
    /// <summary>
    /// 默认文本
    /// </summary>
    public static Color DefaultText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#D2D2D2");
        return GetColor("#090909");
      }
    }

    /// <summary>
    /// 默认文本 Hover
    /// </summary>
    public static Color DefaultTextHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#BDBDBD");
        return GetColor("#090909");
      }
    }

    /// <summary>
    /// 错误消息的文本颜色
    /// </summary>
    public static Color ErrorText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#D32222");
        return GetColor("#5A0000");
      }
    }

    /// <summary>
    /// 未访问链接的文字颜色
    /// </summary>
    public static Color LinkText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#4C7EFF");
        return GetColor("#4C7EFF");
      }
    }

    /// <summary>
    /// 已访问链接的文字颜色
    /// </summary>
    public static Color VisitedLinkText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#FF00FF");
        return GetColor("#AA00AA");
      }
    }

    /// <summary>
    /// 警告消息的文字颜色
    /// </summary>
    public static Color WarningText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#F4BC02");
        return GetColor("#333308");
      }
    }
    #endregion

    #region Windows and Component Text Colors 窗口和组件文本颜色
    /// <summary>
    /// 选定项目或选定文本的文本颜色
    /// </summary>
    public static Color HighlightText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#4C7EFF");
        return GetColor("#0032E6");
      }
    }

    /// <summary>
    /// 当控件没有焦点时，选定项目或选定文本的文本颜色
    /// </summary>
    public static Color HighlightTextInactive {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#FFFFFF");
        return GetColor("#FFFFFF");
      }
    }

    /// <summary>
    /// 标签控件的文字颜色
    /// </summary>
    public static Color LabelText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#C4C4C4");
        return GetColor("#090909");
      }
    }

    /// <summary>
    /// 标签控件的文字颜色 Focus
    /// </summary>
    public static Color LabelTextFocus {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#81B4FF");
        return GetColor("#003C88");
      }
    }

    /// <summary>
    /// 预览控制覆盖的文本颜色
    /// </summary>
    public static Color PreviewOverlayText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#DEDEDE");
        return GetColor("#FFFFFF");
      }
    }

    /// <summary>
    /// 窗口的文字颜色
    /// </summary>
    public static Color WindowText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#BDBDBD");
        return GetColor("#090909");
      }
    }
    #endregion

    #region Toolbar Text Colors 工具栏文本颜色
    /// <summary>
    /// 编辑器窗口选项卡的文字颜色
    /// </summary>
    public static Color TabText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#BDBDBD");
        return GetColor("#090909");
      }
    }

    /// <summary>
    /// 工具栏按钮文本
    /// </summary>
    public static Color ToolbarButtonText {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#C4C4C4");
        return GetColor("#090909");
      }
    }

    /// <summary>
    /// 工具栏按钮文本 Checked
    /// </summary>
    public static Color ToolbarButtonTextChecked {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#C4C4C4");
        return GetColor("#090909");
      }
    }

    /// <summary>
    /// 工具栏按钮文本 Hover
    /// </summary>
    public static Color ToolbarButtonTextHover {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#BDBDBD");
        return GetColor("#090909");
      }
    }
    #endregion

    #region Icon 图标颜色
    /// <summary>
    /// 不需要颜色编码的图标使用此颜色
    /// </summary>
    public static Color IconPrimaryGray {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#C4C4C4");
        return GetColor("#555555");
      }
    }

    /// <summary>
    /// 主要用于 Graphics
    /// </summary>
    public static Color IconSecondaryBlue {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#80D8FF");
        return GetColor("#0C6CCB");
      }
    }

    /// <summary>
    /// 主要用于 Unity徽标符号
    /// </summary>
    public static Color IconSecondaryCharcoalWhite {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#2F2F2F");
        return GetColor("#f0f0f0");
      }
    }

    /// <summary>
    /// 主要用于 Navigation 
    /// </summary>
    public static Color IconSecondaryCoral {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#FF6E40");
        return GetColor("#B73C15");
      }
    }

    /// <summary>
    /// 主要用于 Animation  
    /// </summary>
    public static Color IconSecondaryCyan {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#80FFE6");
        return GetColor("#0F7686");
      }
    }

    /// <summary>
    /// 主要用于 Physics  
    /// </summary>
    public static Color IconSecondaryGreen {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#B2FF59");
        return GetColor("#2E7D32");
      }
    }

    /// <summary>
    /// 主要用于 Network Constraints
    /// </summary>
    public static Color IconSecondaryMagenta {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#E78DDC");
        return GetColor("#CD237F");
      }
    }

    /// <summary>
    /// 主要用于 2D
    /// </summary>
    public static Color IconSecondaryPurple {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#AF91F4");
        return GetColor("#673AB7");
      }
    }

    /// <summary>
    /// 主要用于 Lights
    /// </summary>
    public static Color IconSecondaryYellow {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#FFC107");
        return GetColor("#C99700");
      }
    }

    /// <summary>
    /// 无法创建视觉上的深度时使用的，很少使用
    /// </summary>
    public static Color IconFeedbackHalfGray {
      get {
        if (EditorGUIUtility.isProSkin)
          return new Color(196, 196, 196, 0.5f);
        return new Color(85, 85, 85, 0.5f);
      }
    }

    /// <summary>
    /// 主要用于 建议活跃状态和消息
    /// </summary>
    public static Color IconFeedbackCobalt {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#57AEFF");
        return GetColor("#0F49BD");
      }
    }

    /// <summary>
    /// 主要用于 暗示中性状态
    /// </summary>
    public static Color IconFeedbackGray {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#555555");
        return GetColor("#C4C4C4");
      }
    }

    /// <summary>
    /// 主要用于 提出积极的状态和信息
    /// </summary>
    public static Color IconFeedbackGreen {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#14D368");
        return GetColor("#008126");
      }
    }

    /// <summary>
    /// 主要用于 建议错误状态和消息
    /// </summary>
    public static Color IconFeedbackScarlet {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#14D368");
        return GetColor("#008126");
      }
    }

    /// <summary>
    /// 主要用于 需要在选定状态上更改颜色的图标
    /// </summary>
    public static Color IconFeedbackWhite {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#14D368");
        return GetColor("#008126");
      }
    }

    /// <summary>
    /// 主要用于 建议警告状态和消息
    /// </summary>
    public static Color IconFeedbackYellow {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#14D368");
        return GetColor("#008126");
      }
    }

    /// <summary>
    /// 重音颜色用于交流以删除
    /// </summary>
    public static Color IconAccentRed {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#FD8678");
        return GetColor("#B25553");
      }
    }

    /// <summary>
    /// 重音颜色用于交流以修改
    /// </summary>
    public static Color IconAccentPurple {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#A1A3FF");
        return GetColor("#6D66CC");
      }
    }

    /// <summary>
    /// 重音颜色用于交流以选择
    /// </summary>
    public static Color IconAccentOrange {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#A1A3FF");
        return GetColor("#6D66CC");
      }
    }

    /// <summary>
    /// 重音颜色用于交流以添加
    /// </summary>
    public static Color IconAccentSpringGreen {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#69E39F");
        return GetColor("#00876A");
      }
    }

    /// <summary>
    /// 这种重音颜色用于通用使用。
    /// </summary>
    public static Color IconAccentSteelBlue {
      get {
        if (EditorGUIUtility.isProSkin)
          return GetColor("#4B88AC");
        return GetColor("#4B88AC");
      }
    }
    #endregion
  }

}
