using System;
using System.Collections.Generic;

namespace Fishwork.Core {

  public struct Observable<T> {
    public event Action<T> OnValueChanged;
    private T _value;

    public T Value {
      get => _value;
      set {
        if (EqualityComparer<T>.Default.Equals(_value, value)) {
          _value = value;
          OnValueChanged?.Invoke(_value);
        }
      }
    }

    public Observable(T value) {
      _value = value;
      OnValueChanged = null;
    }
  }

}
