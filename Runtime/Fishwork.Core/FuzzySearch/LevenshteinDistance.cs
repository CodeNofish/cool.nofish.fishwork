using System;

namespace Fishwork.Core {

  /// <summary>
  /// Levenshtein距离，增删替换
  /// </summary>
  public class LevenshteinDistance : IStringSimilarity {
    public int GetDistance(string str1, string str2) {
      int len1 = str1.Length;
      int len2 = str2.Length;
      if (len1 == 0) return len2;
      if (len2 == 0) return len1;

      if (len1 < len2) return GetDistance(str2, str1);

      int[] dp = new int[len2 + 1];

      for (int j = 0; j <= len2; j++)
        dp[j] = j;

      for (int i = 1; i <= len1; i++) {
        int previousDiagonal = dp[0];
        dp[0] = i;
        for (int j = 1; j <= len2; j++) {
          int temp = dp[j];
          int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;
          dp[j] = Math.Min(
            Math.Min(
              dp[j] + 1,
              dp[j - 1] + 1
            ),
            previousDiagonal + cost
          );
          previousDiagonal = temp;
        }
      }

      return dp[len2];
    }

    public double GetSimilarity(string str1, string str2) {
      int maxLength = Math.Max(str1.Length, str2.Length);
      if (maxLength == 0) return 1.0; // 如果两个字符串都为空，则认为完全匹配
      return 1.0 - (double)GetDistance(str1, str2) / maxLength;
    }
  }

}
