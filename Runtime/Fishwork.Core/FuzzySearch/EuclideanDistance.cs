using System;
using System.Collections.Generic;

namespace Fishwork.Core {

  /// <summary>
  /// 欧几里得距离
  /// </summary>
  public static class EuclideanDistance {
    public static double GetDistance(Dictionary<string, double> vectorA, Dictionary<string, double> vectorB) {
      double sumSquaredDifferences = 0;

      // 遍历 vectorA 的非零元素
      foreach (var key in vectorA.Keys) {
        double valueA = vectorA[key];
        double valueB = vectorB.ContainsKey(key) ? vectorB[key] : 0;
        sumSquaredDifferences += Math.Pow(valueA - valueB, 2);
      }

      // 遍历 vectorB 的非零元素（只处理未在 vectorA 中出现的键）
      foreach (var key in vectorB.Keys) {
        if (!vectorA.ContainsKey(key)) {
          double valueB = vectorB[key];
          sumSquaredDifferences += Math.Pow(valueB, 2);
        }
      }

      // 计算欧几里得距离
      return Math.Sqrt(sumSquaredDifferences);
    }
  }

}
