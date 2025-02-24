using NUnit.Framework;
using UnityEngine;

namespace Fishwork.Core.Tests {
  
  public class TestSingletonManager : MonoSingleton<TestSingletonManager> {
    public void SayHello() {
      Debug.Log("Hello!");
    }
  }

  public class MonoSingletonTest {
    [Test]
    public void Test() {
      TestSingletonManager.Instance.SayHello();
    }
  }

}
