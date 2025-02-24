using System;

namespace Fishwork.Core {

  public class LongestCommonSubsequenceDistance : IStringSimilarity {
    public int GetDistance(string str1, string str2) {
      int len1 = str1.Length;
      int len2 = str2.Length;
      if (len1 == 0) return len2;
      if (len2 == 0) return len1;

      if (len1 < len2) return GetDistance(str2, str1);

      int[] dp = new int[len2 + 1];

      for (int i = 1; i <= len1; i++) {
        int previousDiagonal = 0; // 保存左上角的值
        for (int j = 1; j <= len2; j++) {
          int temp = dp[j]; // 保存当前值，用于下一轮计算
          if (str1[i - 1] == str2[j - 1]) {
            dp[j] = previousDiagonal + 1;
          } else {
            dp[j] = Math.Max(dp[j], dp[j - 1]);
          }
          previousDiagonal = temp; // 更新左上角的值
        }
      }
      return dp[len2];
    }

    public double GetSimilarity(string str1, string str2) {
      int maxLength = Math.Max(str1.Length, str2.Length);
      if (maxLength == 0) return 1.0;
      return 1.0 - (double)GetDistance(str1, str2) / maxLength;
    }
  }

}
