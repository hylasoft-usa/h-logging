using Hylasoft.Logging.Configuration.Types;

namespace Hylasoft.Logging.Configuration.Interfaces.Base
{
  public interface IResultLoggingConfig
  {
    string LogId { get; }

    LoggingLevels? Level { get; }

    bool? VerboseOnError { get; }
  }
} 
