using System.Reflection;

namespace Fishwork.Serialize {

  public interface ISerializationPolicy {
    public string ID { get; }
    public bool ShouldSerializeMember(MemberInfo member);
  }

}
