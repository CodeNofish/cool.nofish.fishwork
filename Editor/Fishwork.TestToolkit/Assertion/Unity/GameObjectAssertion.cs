using UnityEngine;

namespace Fishwork.TestToolkit {

  public sealed class GameObjectAssertion : ObjectAssertion<GameObject, GameObjectAssertion> {
    public GameObjectAssertion(GameObject subject, string caller) : base(subject, caller) { }

    /// <summary>
    /// 游戏对象名为指定值
    /// </summary>
    public GameObjectAssertion IsName(string gameObjectName) {
      if (Subject != null && Subject.name.Equals(gameObjectName)) {
        ReportSuccess();
        return this;
      }
      ReportFailure($"游戏对象名为 {gameObjectName}", $"{Subject.name}");
      return this;
    }
  }

}
