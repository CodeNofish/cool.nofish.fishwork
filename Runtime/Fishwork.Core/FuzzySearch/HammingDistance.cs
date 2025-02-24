using System;

namespace Fishwork.Core {

  /// <summary>
  /// 汉明距离，替换
  /// </summary>
  public class HammingDistance : IStringSimilarity {
    public int GetDistance(string str1, string str2) {
      int distance = 0;
      int minLength = Math.Min(str1.Length, str2.Length);
      for (int i = 0; i < minLength; i++) {
        if (str1[i] != str2[i]) distance++;
      }
      distance += Math.Abs(str1.Length - str2.Length);
      return distance;
    }

    public double GetSimilarity(string str1, string str2) {
      int maxLength = Math.Max(str1.Length, str2.Length);
      if (maxLength == 0) return 1.0;
      return 1.0 - (double)GetDistance(str1, str2) / maxLength;
    }
  }

}
