using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Fishwork.Core.Tests {

  public class FuzzySearchTest {
    private List<string> _candidates = new() {
      "apple",
      "apricot",
      "banana",
      "avocado",
      "cherry",
      "coconut",
      "grape",
      "kiwi",
      "lemon",
      "mango"
    };

    [Test]
    public void Test_Search() {
      FuzzySearch fuzzySearch = new FuzzySearch(_candidates, new JaroWinklerDistance());
      string searchTerm = "aple";
      var results = fuzzySearch.Search(searchTerm, 5);

      Debug.Log($"搜索词: {searchTerm}");
      Debug.Log("搜索结果（按相似度排名）:");
      foreach (var result in results) {
        Debug.Log($"{result.Content} (相似度: {result.Similarity:P2})");
      }
    }
  }

}
