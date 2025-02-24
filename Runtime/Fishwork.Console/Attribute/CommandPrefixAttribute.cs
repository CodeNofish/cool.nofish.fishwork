using System;

namespace Fishwork.Console {

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Assembly)]
  public class CommandPrefixAttribute : Attribute {
    public string Prefix;
  }

}
