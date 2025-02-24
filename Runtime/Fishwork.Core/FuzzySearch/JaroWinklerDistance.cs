using System;

namespace Fishwork.Core {

  public class JaroWinklerDistance : IStringSimilarity {
    public double GetJaroWinklerSimilarity(string str1, string str2) {
      // Jaro 相似度
      double jaro = GetJaroSimilarity(str1, str2);

      // 前缀匹配长度（最多 4 个字符）
      int prefixLength = 0;
      int maxPrefixLength = Math.Min(4, Math.Min(str1.Length, str2.Length));
      while (prefixLength < maxPrefixLength && str1[prefixLength] == str2[prefixLength]) {
        prefixLength++;
      }

      // Jaro-Winkler 相似度
      double winkler = jaro + prefixLength * 0.1 * (1 - jaro);
      return winkler;
    }

    public double GetJaroSimilarity(string str1, string str2) {
      int len1 = str1.Length;
      int len2 = str2.Length;

      if (len1 == 0 || len2 == 0) {
        return 0.0;
      }

      // 匹配窗口大小
      int matchDistance = Math.Max(len1, len2) / 2 - 1;

      // 记录匹配的字符
      bool[] str1Matches = new bool[len1];
      bool[] str2Matches = new bool[len2];

      int matches = 0;
      int transpositions = 0;

      // 遍历 str1 和 str2，计算匹配字符数和换位字符数
      for (int i = 0; i < len1; i++) {
        int start = Math.Max(0, i - matchDistance);
        int end = Math.Min(i + matchDistance + 1, len2);

        for (int j = start; j < end; j++) {
          if (!str2Matches[j] && str1[i] == str2[j]) {
            str1Matches[i] = true;
            str2Matches[j] = true;
            matches++;
            break;
          }
        }
      }

      if (matches == 0) {
        return 0.0;
      }

      // 计算换位字符数
      int k = 0;
      for (int i = 0; i < len1; i++) {
        if (str1Matches[i]) {
          while (!str2Matches[k]) {
            k++;
          }
          if (str1[i] != str2[k]) {
            transpositions++;
          }
          k++;
        }
      }

      // Jaro 相似度公式
      double jaro = ((double)matches / len1 + (double)matches / len2 + (double)(matches - transpositions / 2) / matches) / 3;
      return jaro;
    }

    public double GetSimilarity(string str1, string str2) {
      return GetJaroWinklerSimilarity(str1, str2);
    }
  }

}
