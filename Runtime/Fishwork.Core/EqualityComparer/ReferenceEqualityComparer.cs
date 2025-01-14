﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Fishwork.Core {

  public class ReferenceEqualityComparer<T> : IEqualityComparer<T> where T : class  {
    public static ReferenceEqualityComparer<T>  Default = new();

    public bool Equals(T x, T y) {
      return ReferenceEquals(x, y);
    }

    public int GetHashCode(T obj) {
      return RuntimeHelpers.GetHashCode(obj);
    }
  }

}
