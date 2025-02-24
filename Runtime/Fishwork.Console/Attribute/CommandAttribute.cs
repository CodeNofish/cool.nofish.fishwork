using System;

namespace Fishwork.Console {

  [AttributeUsage(AttributeTargets.Method)]
  public class CommandAttribute : Attribute {
    public string Alias;
    public string Description;
  }

}
