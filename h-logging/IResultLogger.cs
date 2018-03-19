using Hylasoft.Resolution;

namespace Hylasoft.Logging
{
  public interface IResultLogger
  {
    string Id { get; }

    Result Log(Result result);

    Result LogSynchronous(Result result);
  }
}
