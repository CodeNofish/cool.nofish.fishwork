using NUnit.Framework;
using UnityEngine;

namespace Fishwork.Script.Tests {

  public class Test {
    [Test]
    public void TestA() {
      // 测试代码片段
      string input = @"
            var x = 42;
            const y = 'Hello, World!';
            if (x == 42) {
                print(y);
            } else {
                print('Not 42');
            }
            // 这是一个单行注释
            /* 这是一个
               多行注释 */
            function add(a, b) {
                return a + b;
            }
        ";
      
      // 创建 Lexer
      Lexer lexer = new Lexer(input);
      
      Token token;
      do {
        token = lexer.NextToken();
        Debug.Log(token);
      } while (token.Type != TokenType.EOF);
    }
  }

}
