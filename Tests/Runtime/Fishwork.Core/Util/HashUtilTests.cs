using NUnit.Framework;

namespace Fishwork.Core.Tests {

  public class HashUtilTests {
    [Test]
    public void GetMD5Hash_Test() {
      var md5Hash = HashUtil.GetMD5Hash("Hello, World!");
      Assert.AreEqual("65a8e27d8879283831b664bd8b7f0ad4", md5Hash);
    }
    
    [Test]
    public void GetSHA256Hash_Test() {
      var sha256Hash = HashUtil.GetSHA256Hash("Hello, World!");
      Assert.AreEqual("dffd6021bb2bd5b0af676290809ec3a53191dd81c7f70a4b28688a362182986f", sha256Hash);
    }
  }

}
