﻿using UnityEngine;

namespace Fishwork.Inspector {

  public class RangeAttribute : PropertyAttribute {
    public float Min { get; private set; }
    public float Max { get; private set; }

    public RangeAttribute(float min, float max) {
      Min = min;
      Max = max;
    }
  }

}
