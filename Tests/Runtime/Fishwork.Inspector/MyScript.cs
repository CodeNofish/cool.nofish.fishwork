using UnityEngine;

namespace Fishwork.Inspector.Tests {

  public class MyScript : MonoBehaviour {
    [Range(0, 100)]
    public float health;
  }

}
