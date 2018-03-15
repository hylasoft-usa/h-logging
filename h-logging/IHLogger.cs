using Hylasoft.Resolution;

namespace Hylasoft.Logging
{
  public interface IHLogger
  {
    Result Log(Result result);

    Result LogSynchronous(Result result);
  }
}
