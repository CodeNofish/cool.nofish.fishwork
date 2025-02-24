using System;

namespace Fishwork.Core {

  /// <summary>
  /// 可比较的版本号
  /// </summary>
  public class Version : IComparable<Version> {
    /// <summary>
    /// 主版本号
    /// </summary>
    public int Major { get; }
    
    /// <summary>
    /// 次版本号
    /// </summary>
    public int Minor { get; }

    public Version(int major, int minor) {
      if (major < 0 || minor < 0)
        throw new ArgumentException("版本号不能为负数");
      Major = major;
      Minor = minor;
    }

    public int CompareTo(Version other) {
      if (other == null)
        return 1;
      if (Major != other.Major)
        return Major.CompareTo(other.Major);
      return Minor.CompareTo(other.Minor);
    }

    public override bool Equals(object obj) {
      if (obj is Version other)
        return Major == other.Major && Minor == other.Minor;
      return false;
    }

    public override int GetHashCode() {
      return HashCode.Combine(Major, Minor);
    }

    public override string ToString() {
      return $"{Major}.{Minor}";
    }

    public static bool operator ==(Version v1, Version v2) {
      if (ReferenceEquals(v1, v2))
        return true;
      if (v1 is null || v2 is null)
        return false;
      return v1.Equals(v2);
    }

    public static bool operator !=(Version v1, Version v2) {
      return !(v1 == v2);
    }

    public static bool operator >(Version v1, Version v2) {
      Guard.AgainstNull(v1, nameof(v1));
      Guard.AgainstNull(v2, nameof(v2));
      return v1.CompareTo(v2) > 0;
    }

    public static bool operator <(Version v1, Version v2) {
      Guard.AgainstNull(v1, nameof(v1));
      Guard.AgainstNull(v2, nameof(v2));
      return v1.CompareTo(v2) < 0;
    }

    public static bool operator >=(Version v1, Version v2) {
      Guard.AgainstNull(v1, nameof(v1));
      Guard.AgainstNull(v2, nameof(v2));
      return v1.CompareTo(v2) >= 0;
    }

    public static bool operator <=(Version v1, Version v2) {
      Guard.AgainstNull(v1, nameof(v1));
      Guard.AgainstNull(v2, nameof(v2));
      return v1.CompareTo(v2) <= 0;
    }
  }

}
