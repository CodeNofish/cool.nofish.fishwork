using System.Security.Cryptography;
using System.Text;

namespace Fishwork.Core {

  public static class HashUtil {
    /// <summary>
    /// 获取输入字符串 计算出的MD5值（16字节）
    /// </summary>
    public static string GetMD5Hash(string input) {
      using var md5 = MD5.Create();
      var inputBytes = Encoding.UTF8.GetBytes(input);
      var hashBytes = md5.ComputeHash(inputBytes);
      StringBuilder sb = new StringBuilder();
      foreach (var b in hashBytes)
        sb.Append(b.ToString("x2")); // "x2" 表示两位小写的十六进制
      return sb.ToString();
    }
    
    /// <summary>
    /// 获取输入 计算出的MD5值（16字节）
    /// </summary>
    public static byte[] GetMD5Hash(byte[] inputBytes) {
      using var md5 = MD5.Create();
      return md5.ComputeHash(inputBytes);
    }

    /// <summary>
    /// 获取输入字符串 计算出的SHA-256值（32字节），比MD5更安全
    /// </summary>
    public static string GetSHA256Hash(string input) {
      using var sha256 = SHA256.Create();
      var inputBytes = Encoding.UTF8.GetBytes(input);
      var hashBytes = sha256.ComputeHash(inputBytes);
      StringBuilder sb = new StringBuilder();
      foreach (var b in hashBytes)
        sb.Append(b.ToString("x2")); // "x2" 表示两位小写的十六进制
      return sb.ToString();
    }
    
    /// <summary>
    /// 获取输入 计算出的SHA-256值（32字节），比MD5更安全
    /// </summary>
    public static byte[] GetSHA256Hash(byte[] inputBytes) {
      using var sha256 = SHA256.Create();
      return sha256.ComputeHash(inputBytes);
    }
  }

}
