using Hylasoft.Resolution;

namespace Hylasoft.Logging
{
  public interface IResultLogger
  {
    Result Log(Result result);

    Result LogSynchronous(Result result);
  }
}
