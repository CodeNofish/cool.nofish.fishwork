using System.Collections.Generic;

namespace Fishwork.Core {

  /// <summary>
  /// 杰卡德相似系数，计算两个集合的交集与并集的比例来评估它们的相似性 
  /// </summary>
  public static class JaccardSimilarity {
    public static double OptimizedJaccardSimilarity(HashSet<string> setA, HashSet<string> setB) {
      if (setA.Count == 0 || setB.Count == 0)
        return 0; // 如果任一集合为空，相似度为 0

      // 计算交集
      var intersection = new HashSet<string>(setA);
      intersection.IntersectWith(setB);

      // 计算并集
      var union = new HashSet<string>(setA);
      union.UnionWith(setB);

      // 计算 Jaccard 相似系数
      return (double)intersection.Count / union.Count;
    }
  }

}
