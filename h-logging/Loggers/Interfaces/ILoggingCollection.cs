using System.Collections.Generic;
using Hylasoft.Resolution;

namespace Hylasoft.Logging.Loggers.Interfaces
{
  public interface ILoggingCollection : IResultLogger, IEnumerable<IResultLogger>
  {
    Result Add(params IResultLogger[] loggers);

    Result Add(IEnumerable<IResultLogger> loggers);

    Result Add(IResultLogger logger);

    Result Remove(string logId);
  }
}
