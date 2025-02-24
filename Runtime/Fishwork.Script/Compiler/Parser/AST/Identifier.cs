using System;
using System.Text;

namespace Fishwork.Script {

  // 标识符
  public class Identifier : ASTNode {
    public string Name { get; }

    public Identifier(string name) {
      Name = name;
    }

    public override void Print(StringBuilder stringBuilder, int indent = 0) {
      string indentStr = new string(' ', indent * 2);
      Console.WriteLine($"{indentStr}Identifier: {Name}");
    }
  }

}
