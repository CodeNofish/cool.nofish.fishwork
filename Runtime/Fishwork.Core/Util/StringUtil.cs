using System;

namespace Fishwork.Core {

  public static class StringUtil {

    /// <summary>
    /// Levenshtein距离，插入删除替换 
    /// </summary>
    public static int CalculateLevenshteinDistance(string source, string target) {
      if (string.IsNullOrEmpty(source))
        return string.IsNullOrEmpty(target) ? 0 : target.Length;
      if (string.IsNullOrEmpty(target))
        return source.Length;

      int sourceLength = source.Length;
      int targetLength = target.Length;
      int[] previousRow = new int[targetLength + 1];
      int[] currentRow = new int[targetLength + 1];

      for (int j = 0; j <= targetLength; j++)
        previousRow[j] = j;

      for (int i = 1; i <= sourceLength; i++) {
        currentRow[0] = i;

        for (int j = 1; j <= targetLength; j++) {
          int cost = (source[i - 1] == target[j - 1]) ? 0 : 1;
          currentRow[j] = Math.Min(
            Math.Min(previousRow[j] + 1, // 删除
              currentRow[j - 1] + 1), // 插入
            previousRow[j - 1] + cost); // 替换
        }
        // 交换行
        (previousRow, currentRow) = (currentRow, previousRow);
      }

      return previousRow[targetLength];
    }

    /// <summary>
    /// Damerau-Levenshtein距离，插入删除替换交换
    /// </summary>
    public static int CalculateDamerauLevenshtein(string source, string target) {
      if (string.IsNullOrEmpty(source))
        return string.IsNullOrEmpty(target) ? 0 : target.Length;
      if (string.IsNullOrEmpty(target))
        return source.Length;

      int sourceLength = source.Length;
      int targetLength = target.Length;
      int[] currentRow = new int[targetLength + 1];
      int[] previousRow = new int[targetLength + 1];
      int[] previousPreviousRow = new int[targetLength + 1];

      // 初始化第一行
      for (int j = 0; j <= targetLength; j++)
        previousRow[j] = j;

      for (int i = 1; i <= sourceLength; i++) {
        currentRow[0] = i;
        for (int j = 1; j <= targetLength; j++) {
          int cost = (source[i - 1] == target[j - 1]) ? 0 : 1;
          // 计算插入、删除和替换的最小值
          currentRow[j] = Math.Min(
            Math.Min(previousRow[j] + 1, // 删除
              currentRow[j - 1] + 1), // 插入
            previousRow[j - 1] + cost); // 替换
          // 检查是否需要交换操作
          if (i > 1 && j > 1 && source[i - 1] == target[j - 2] && source[i - 2] == target[j - 1]) {
            currentRow[j] = Math.Min(currentRow[j], previousPreviousRow[j - 2] + cost);
          }
        }
        // 更新行
        for (int j = 0; j <= targetLength; j++) {
          previousPreviousRow[j] = previousRow[j];
          previousRow[j] = currentRow[j];
        }
      }

      return previousRow[targetLength];
    }

    /// <summary>
    /// LCS距离
    /// </summary>
    public static int CalculateLongestCommonSubsequenceDistance(string source, string target) {
      int lcsLength = GetLCS(source, target);
      return source.Length + target.Length - 2 * lcsLength;
    }

    private static int GetLCS(string s1, string s2) {
      int m = s1.Length, n = s2.Length;
      int[] prev = new int[n + 1];
      int[] curr = new int[n + 1];
      for (int i = 1; i <= m; i++) {
        for (int j = 1; j <= n; j++) {
          if (s1[i - 1] == s2[j - 1])
            curr[j] = prev[j - 1] + 1;
          else
            curr[j] = Math.Max(prev[j], curr[j - 1]);
        }
        Array.Copy(curr, prev, n + 1); // 复制当前行到上一行
      }
      return prev[n];
    }

    /// <summary>
    /// Hamming距离，用于等长字符串比较
    /// </summary>
    public static int CalculateHammingDistance(string source, string target) {
      if (source.Length != target.Length)
        throw new ArgumentException("Hamming距离需要长度相等的字符串");
      int distance = 0;
      for (int i = 0; i < source.Length; i++)
        if (source[i] != target[i])
          distance++;
      return distance;
    }

    /// <summary>
    /// Jaro-Winkler距离，短字符串匹配
    /// </summary>
    public static double CalculateJaroWinklerDistance(string source, string target) {
      double jaroDistance = CalculateJaroDistance(source, target);
      int prefixLength = GetCommonPrefixLength(source, target);
      // Jaro-Winkler 调整因子
      double winklerScalingFactor = 0.1;
      double winklerDistance = jaroDistance + (prefixLength * winklerScalingFactor * (1 - jaroDistance));
      return winklerDistance;
    }

    private static double CalculateJaroDistance(string str1, string str2) {
      if (str1 == str2)
        return 1.0;

      int len1 = str1.Length;
      int len2 = str2.Length;

      // 匹配窗口大小
      int matchDistance = Math.Max(len1, len2) / 2 - 1;

      // 匹配的字符
      bool[] matches1 = new bool[len1];
      bool[] matches2 = new bool[len2];

      int matches = 0;
      int transpositions = 0;

      // 查找匹配的字符
      for (int i = 0; i < len1; i++) {
        int start = Math.Max(0, i - matchDistance);
        int end = Math.Min(i + matchDistance + 1, len2);

        for (int j = start; j < end; j++) {
          if (!matches2[j] && str1[i] == str2[j]) {
            matches1[i] = true;
            matches2[j] = true;
            matches++;
            break;
          }
        }
      }

      if (matches == 0)
        return 0.0;

      // 计算换位次数
      int k = 0;
      for (int i = 0; i < len1; i++) {
        if (matches1[i]) {
          while (!matches2[k])
            k++;
          if (str1[i] != str2[k])
            transpositions++;
          k++;
        }
      }

      double jaro = ((double)matches / len1 + (double)matches / len2 + (double)(matches - transpositions / 2) / matches) / 3.0;
      return jaro;
    }

    private static int GetCommonPrefixLength(string str1, string str2) {
      int minLength = Math.Min(str1.Length, str2.Length);
      int prefixLength = 0;
      for (int i = 0; i < minLength; i++) {
        if (str1[i] == str2[i])
          prefixLength++;
        else
          break;
      }
      // 限制前缀长度为 4
      return Math.Min(prefixLength, 4);
    }
  }

}
