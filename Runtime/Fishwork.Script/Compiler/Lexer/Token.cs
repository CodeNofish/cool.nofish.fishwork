namespace Fishwork.Script {

  public class Token {
    public TokenType Type { get; }
    public string Value { get; }
    public int Line { get; }
    public int Column { get; }

    public Token(TokenType type, string value, int line, int column) {
      Line = line;
      Column = column;
      Type = type;
      Value = value;
    }

    public override string ToString() {
      var valueStr = Value.Replace("\n", "\\n");
      if (valueStr.Length > 32)
        valueStr = valueStr.Substring(0, 32) + "...";
      return $"{Type} (Value: {valueStr}, Line: {Line}, Column: {Column})";
    }
  }

}
