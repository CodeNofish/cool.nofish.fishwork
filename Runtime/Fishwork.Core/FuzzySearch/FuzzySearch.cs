using System.Collections.Generic;
using System.Linq;

namespace Fishwork.Core {

  public class FuzzySearch {
    private List<string> _candidates;
    private IStringSimilarity _similarity;

    public FuzzySearch(List<string> candidates, IStringSimilarity stringSimilarity) {
      _candidates = candidates;
      _similarity = stringSimilarity;
    }

    public List<SearchResult> Search(string searchTerm, int limit) {
      var results = _candidates
        .Select(candidate => new SearchResult() {
          Content = candidate,
          Similarity = _similarity.GetSimilarity(searchTerm, candidate),
        })
        .OrderByDescending(result => result.Similarity)
        .Take(limit)
        .ForEach((result, count) => result.Rank = count, 1)
        .ToList();
      return results;
    }

    public class SearchResult {
      public string Content { get; set; }
      public double Similarity { get; set; }
      public int Rank { get; set; }
    }
  }

}
