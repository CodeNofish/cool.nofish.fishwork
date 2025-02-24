using NUnit.Framework;
using UnityEngine;

namespace Fishwork.Core.Tests {

  public class TempTest {
    [Test]
    public void Test() {
      Debug.Log(Application.unityVersion);
      Debug.Log(Application.version);
    }
  }

}
