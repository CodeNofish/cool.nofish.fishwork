using System.Runtime.CompilerServices;

namespace Fishwork.Core {

  public static class PathUtil {
    /// <summary>
    /// 标准化路径
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string NormalizePath(this string path) {
      return path.Replace('\\', '/').Trim('/');
    }
  }

}
