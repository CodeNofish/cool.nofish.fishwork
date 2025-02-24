using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Fishwork.Core.Tests {

  public class SequenceExtensionTest {
    private static readonly List<string> Sequence = new() {
      "A", "B", "C", "D", "E",
    };

    [Test]
    public void Test_ForEach() {
      Sequence.ForEach(Debug.Log);
    }

    [Test]
    public void Test_ForEach_Count() {
      Sequence.ForEach((str,count) => Debug.Log($"{str}:{count}"), 1);
    }
  }

}
