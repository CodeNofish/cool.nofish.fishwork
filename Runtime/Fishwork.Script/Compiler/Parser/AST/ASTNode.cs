using System.Text;

namespace Fishwork.Script {

  public abstract class ASTNode {
    public abstract void Print(StringBuilder stringBuilder, int indent = 0);
  }

}
