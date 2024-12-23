namespace Fishwork.Serialize {

  /// <summary>
  /// 序列化格式化器
  /// </summary>
  public interface ISerializeFormatter<T> {
    /// <summary>
    /// 序列化过程
    /// </summary>
    public void Serialize(T value);

    /// <summary>
    /// 反序列化过程
    /// </summary>
    /// <returns></returns>
    public T Deserialize();
  }

}
