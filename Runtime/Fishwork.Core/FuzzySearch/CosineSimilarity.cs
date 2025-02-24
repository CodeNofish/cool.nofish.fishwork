using System;
using System.Collections.Generic;
using System.Linq;

namespace Fishwork.Core {

  /// <summary>
  /// 余弦相似度，衡量两个向量之间相似性，需要向量化表示
  /// </summary>
  public static class CosineSimilarity {
    public static double GetSimilarity(Dictionary<string, double> vectorA, Dictionary<string, double> vectorB) {
      // 计算向量的点积
      double dotProduct = 0;
      foreach (var key in vectorA.Keys) {
        if (vectorB.ContainsKey(key)) {
          dotProduct += vectorA[key] * vectorB[key];
        }
      }

      // 计算向量的模（L2 范数）
      double normA = Math.Sqrt(vectorA.Values.Sum(x => x * x));
      double normB = Math.Sqrt(vectorB.Values.Sum(x => x * x));

      // 计算余弦相似度
      if (normA == 0 || normB == 0) {
        return 0; // 避免除以零
      }

      return dotProduct / (normA * normB);
    }
  }

}
