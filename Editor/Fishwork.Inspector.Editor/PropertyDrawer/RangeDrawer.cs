using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fishwork.Inspector.Editor {

  [CustomPropertyDrawer(typeof(RangeAttribute))]
  public class RangeDrawer : PropertyDrawer {
    public readonly string RangeDrawerUxmlPath = "Assets/cool.nofish.fishwork/Editor/Fishwork.Inspector.Editor/PropertyDrawer/RangeDrawer.uxml";
    public readonly string RangeDrawerUssPath = "Assets/cool.nofish.fishwork/Editor/Fishwork.Inspector.Editor/PropertyDrawer/RangeDrawer.uss";
    
    public override VisualElement CreatePropertyGUI(SerializedProperty property) {
      // 加载UXML文件
      var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(RangeDrawerUxmlPath);
      var root = visualTree.CloneTree();

      // 加载USS文件（可选）
      var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(RangeDrawerUssPath);
      root.styleSheets.Add(styleSheet);

      // 获取控件
      var label = root.Q<Label>("label");
      var floatField = root.Q<FloatField>("floatField");
      var slider = root.Q<Slider>("slider");

      // 绑定属性
      label.text = property.displayName;
      floatField.BindProperty(property);
      slider.BindProperty(property);

      // 设置Slider的范围
      RangeAttribute rangeAttribute = (RangeAttribute)attribute;
      slider.lowValue = rangeAttribute.Min;
      slider.highValue = rangeAttribute.Max;

      // 同步FloatField和Slider的值
      floatField.RegisterValueChangedCallback(evt => { slider.value = evt.newValue; });

      slider.RegisterValueChangedCallback(evt => { floatField.value = evt.newValue; });

      return root;
    }
  }

}
