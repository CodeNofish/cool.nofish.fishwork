using System;

namespace Fishwork.Core {

  /// <summary>
  /// Damerau-Levenshtein距离，增删替换交换
  /// </summary>
  public class DamerauLevenshteinDistance : IStringSimilarity {
    public int GetDistance(string str1, string str2) {
      int len1 = str1.Length;
      int len2 = str2.Length;
      if (len1 == 0) return len2;
      if (len2 == 0) return len1;

      if (len1 < len2) return GetDistance(str2, str1);

      int[] previousRow = new int[len2 + 1];
      int[] currentRow = new int[len2 + 1];

      for (int j = 0; j <= len2; j++)
        previousRow[j] = j;

      for (int i = 1; i <= len1; i++) {
        currentRow[0] = i;

        for (int j = 1; j <= len2; j++) {
          int cost = (str1[i - 1] == str2[j - 1]) ? 0 : 1;

          // 插入、删除、替换操作
          currentRow[j] = Math.Min(
            Math.Min(
              previousRow[j] + 1, // 删除
              currentRow[j - 1] + 1 // 插入
            ),
            previousRow[j - 1] + cost // 替换
          );

          // 检查是否需要交换操作
          if (i > 1 && j > 1 && str1[i - 1] == str2[j - 2] && str1[i - 2] == str2[j - 1]) {
            currentRow[j] = Math.Min(
              currentRow[j],
              previousRow[j - 2] + cost // 交换
            );
          }
        }

        (previousRow, currentRow) = (currentRow, previousRow);
      }

      return previousRow[len2];
    }

    public double GetSimilarity(string str1, string str2) {
      int maxLength = Math.Max(str1.Length, str2.Length);
      if (maxLength == 0) return 1.0;
      return 1.0 - (double)GetDistance(str1, str2) / maxLength;
    }
  }

}
