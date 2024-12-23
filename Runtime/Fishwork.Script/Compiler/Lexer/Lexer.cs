using System.Collections.Generic;
using System.Text;

namespace Fishwork.Script {

  public class Lexer {
    private readonly string _input;

    private int _position;
    private int _line = 1;
    private int _column = 1;

    public Lexer(string input) {
      _input = input;
    }

    public Token NextToken() {
      SkipWhitespaceAndComments();

      if (_position >= _input.Length)
        return new Token(TokenType.EOF, "", _line, _column);

      char current = _input[_position];

      // 处理标识符和关键字
      if (char.IsLetter(current) || current == '_')
        return ReadIdentifier();

      // 处理数字字面量
      if (char.IsDigit(current))
        return ReadNumber();

      // 处理字符串字面量
      if (current == '"' || current == '\'')
        return ReadString();

      // 处理符号和运算符
      return current switch {
        '{' => CreateToken(TokenType.LeftBrace, 1),
        '}' => CreateToken(TokenType.RightBrace, 1),
        '[' => CreateToken(TokenType.LeftBracket, 1),
        ']' => CreateToken(TokenType.RightBracket, 1),
        '(' => CreateToken(TokenType.LeftParen, 1),
        ')' => CreateToken(TokenType.RightParen, 1),
        ',' => CreateToken(TokenType.Comma, 1),
        ':' => CreateToken(TokenType.Colon, 1),
        ';' => CreateToken(TokenType.Semicolon, 1),
        '.' => CreateToken(TokenType.Dot, 1),
        '=' when Peek(1) == '=' => CreateToken(TokenType.Equals, 2),
        '=' => CreateToken(TokenType.Assign, 1),
        '!' when Peek(1) == '=' => CreateToken(TokenType.NotEquals, 2),
        '+' => CreateToken(TokenType.Plus, 1),
        '-' => CreateToken(TokenType.Minus, 1),
        '*' => CreateToken(TokenType.Multiply, 1),
        '/' => CreateToken(TokenType.Divide, 1),
        '&' when Peek(1) == '&' => CreateToken(TokenType.LogicalAnd, 2),
        '|' when Peek(1) == '|' => CreateToken(TokenType.LogicalOr, 2),
        _ => CreateToken(TokenType.Illegal, 1)
      };
    }

    private void SkipWhitespaceAndComments() {
      while (_position < _input.Length) {
        if (char.IsWhiteSpace(_input[_position])) {
          HandleWhitespace();
        } else if (_input[_position] == '/' && _position + 1 < _input.Length) {
          if (_input[_position + 1] == '/') SkipSingleLineComment();
          else if (_input[_position + 1] == '*') SkipMultiLineComment();
          else break;
        } else break;
      }
    }

    private Token ReadIdentifier() {
      int start = _position;
      while (_position < _input.Length &&
             (char.IsLetterOrDigit(_input[_position]) || _input[_position] == '_')) {
        _position++;
        _column++;
      }

      var value = _input.Substring(start, _position - start);
      return value switch {
        "var" => new Token(TokenType.Var, value, _line, _column - value.Length),
        "const" => new Token(TokenType.Const, value, _line, _column - value.Length),
        "if" => new Token(TokenType.If, value, _line, _column - value.Length),
        "else" => new Token(TokenType.Else, value, _line, _column - value.Length),
        "for" => new Token(TokenType.For, value, _line, _column - value.Length),
        "while" => new Token(TokenType.While, value, _line, _column - value.Length),
        "function" => new Token(TokenType.Function, value, _line, _column - value.Length),
        "return" => new Token(TokenType.Return, value, _line, _column - value.Length),
        "true" => new Token(TokenType.True, value, _line, _column - value.Length),
        "false" => new Token(TokenType.False, value, _line, _column - value.Length),
        "null" => new Token(TokenType.Null, value, _line, _column - value.Length),
        _ => new Token(TokenType.Identifier, value, _line, _column - value.Length)
      };
    }

    private Token ReadNumber() {
      int start = _position;
      bool hasDot = false;
      while (_position < _input.Length) {
        if (char.IsDigit(_input[_position])) {
          _position++;
          _column++;
        } else if (_input[_position] == '.' && !hasDot) {
          hasDot = true;
          _position++;
          _column++;
        } else break;
      }
      var value = _input.Substring(start, _position - start);
      return new Token(TokenType.NumberLiteral, value, _line, _column - value.Length);
    }

    private Token ReadString() {
      char quoteChar = _input[_position]; // 记录起始引号（单引号或双引号）
      _position++; // 跳过起始引号
      _column++;
      var sb = new StringBuilder();

      while (_position < _input.Length) {
        if (_input[_position] == '\\') {
          _position++;
          _column++;
          sb.Append(_input[_position] switch {
            'n' => '\n',
            'r' => '\r',
            't' => '\t',
            '0' => '\0',
            '\'' => '\'',
            '"' => '"',
            '\\' => '\\',
            var c => c
          });
        } else if (_input[_position] == quoteChar) {
          _position++;
          _column++;
          return new Token(TokenType.StringLiteral, sb.ToString(), _line, _column - sb.Length - 2);
        } else {
          sb.Append(_input[_position]);
        }

        _position++;
        _column++;
      }
      return new Token(TokenType.Illegal, sb.ToString(), _line, _column);
    }

    /// <summary>
    /// 处理空格
    /// </summary>
    private void HandleWhitespace() {
      while (_position < _input.Length && char.IsWhiteSpace(_input[_position])) {
        if (_input[_position] == '\n') {
          _line++;
          _column = 1;
        } else {
          _column++;
        }
        _position++;
      }
    }

    /// <summary>
    /// 跳过单行注释
    /// </summary>
    private void SkipSingleLineComment() {
      _position += 2; // 跳过 //
      _column += 2;
      while (_position < _input.Length && _input[_position] != '\n') {
        _position++;
        _column++;
      }
    }

    /// <summary>
    /// 跳过多行注释
    /// </summary>
    private void SkipMultiLineComment() {
      _position += 2; // 跳过 /*
      _column += 2;
      while (_position < _input.Length) {
        if (_input[_position] == '*' && Peek(1) == '/') {
          _position += 2;
          _column += 2;
          return;
        }
        if (_input[_position] == '\n') {
          _line++;
          _column = 1;
        } else {
          _column++;
        }
        _position++;
      }
    }

    /// <summary>
    /// 向前Peek
    /// </summary>
    private char Peek(int ahead = 1) {
      if (_position + ahead >= _input.Length) return '\0';
      return _input[_position + ahead];
    }

    /// <summary>
    /// 创建Token
    /// </summary>
    private Token CreateToken(TokenType type, int length) {
      var value = _input.Substring(_position, length);
      var token = new Token(type, value, _line, _column);
      _position += length;
      _column += length;
      return token;
    }
  }

}
