using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Loggers.Interfaces;

namespace Hylasoft.Logging.Factories
{
  public interface IResultLoggingFactory
  {
    IFileLogger BuildFileLogger(IFileLogConfig configuration);

    IConsoleLogger BuildConsoleLogger(IConsoleLogConfig configuration);
  }
}
