using System;

namespace Fishwork.TestToolkit {

  public abstract class BaseAssertionScope : IDisposable {
    public BaseAssertionScope Parent;

    public abstract void ReportFailure(BaseAssertionFailureMessage failureMessage);

    public abstract void ReportSuccess();

    public abstract void Dispose();
  }

}
