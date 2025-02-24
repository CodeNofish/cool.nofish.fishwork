namespace Fishwork.Core {

  public interface IObjectPool<T> where T : class {
    public T Borrow();
    public void Return(T obj);
  }

}
