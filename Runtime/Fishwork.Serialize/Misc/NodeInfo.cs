using System;

namespace Fishwork.Serialize {

  public readonly struct NodeInfo : IEquatable<NodeInfo> {
    public static readonly NodeInfo Empty = new();

    public readonly string Name;
    public readonly int Id;
    public readonly Type Type;
    public readonly bool IsArray;
    public readonly bool IsEmpty;

    public NodeInfo(string name, int id, Type type, bool isArray) {
      Name = name;
      Id = id;
      Type = type;
      IsArray = isArray;
      IsEmpty = false;
    }

    public static bool operator ==(NodeInfo a, NodeInfo b) {
      return a.Name == b.Name
             && a.Id == b.Id
             && a.Type == b.Type
             && a.IsArray == b.IsArray
             && a.IsEmpty == b.IsEmpty;
    }

    public static bool operator !=(NodeInfo a, NodeInfo b) {
      return !(a == b);
    }

    public bool Equals(NodeInfo other) {
      return other == this;
    }

    public override bool Equals(object obj) {
      if (ReferenceEquals(obj, null)) return false;
      if (obj is NodeInfo nodeInfo) return nodeInfo == this;
      return false;
    }

    public override int GetHashCode() {
      return HashCode.Combine(Name, Id, Type, IsArray, IsEmpty);
    }
  }

}
