namespace Fishwork.Script {

  public enum TokenType {
    // @formatter:off
    // 关键字
    Var, Const, If, Else, For, While, Function, Return,
    True, False, Null,
    
    // 标识符和字面量
    Identifier, StringLiteral, NumberLiteral,
    
    // 符号
    LeftBrace, RightBrace,       // {}
    LeftParen, RightParen,       // ()
    LeftBracket, RightBracket,   // []
    Comma, Colon, Semicolon,     // , : ;
    Dot,                         // .
    
    // 运算符
    Assign,         // =
    Equals,         // ==
    NotEquals,      // !=
    Plus, Minus, Multiply, Divide, // + - * /
    LogicalAnd,     // &&
    LogicalOr,      // ||
    
    // 其他
    EOF,
    Illegal
    
    // @formatter:on
  }

}
