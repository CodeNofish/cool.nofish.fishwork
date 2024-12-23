using System;
using System.Text;

namespace Fishwork.Script {

  // 变量声明
  public class VariableDeclaration : ASTNode {
    public string Type { get; } // "var" 或 "const"
    public string Name { get; }
    public ASTNode Value { get; } // 初始值表达式

    public VariableDeclaration(string type, string name, ASTNode value) {
      Type = type;
      Name = name;
      Value = value;
    }

    public override void Print(StringBuilder stringBuilder, int indent = 0) {
      string indentStr = new string(' ', indent * 2);
      stringBuilder.AppendLine($"{indentStr}VariableDeclaration: {Type} {Name} =");
      Value.Print(stringBuilder, indent + 1);
    }
  }

}
