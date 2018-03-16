using Hylasoft.Logging.Configuration.Types;

namespace Hylasoft.Logging.Configuration.Interfaces.Base
{
  public interface IResultLoggingConfig
  {
    LoggingLevels? Level { get; }

    bool? VerboseOnError { get; }
  }
} 
