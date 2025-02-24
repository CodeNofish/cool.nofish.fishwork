using System.Globalization;
using System.Text;
using NUnit.Framework;
using UnityEngine;

namespace Fishwork.Localization.Tests {
  
  public class Test {
    [Test]
    public static void ListAllCultures() {
      var cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
      var sb = new StringBuilder();
      int count = 0;
      foreach (var culture in cultures) {
        sb.Append($"{culture.Name} {culture.DisplayName} | ");
        if (count++ > 4) {
          sb.AppendLine();
          count = 0;
        }
      }
      sb.AppendLine($"total: {cultures.Length}");
      Debug.Log(sb.ToString());
    }
  }

}
