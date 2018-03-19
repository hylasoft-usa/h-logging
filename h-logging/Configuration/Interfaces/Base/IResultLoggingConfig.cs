using Hylasoft.Logging.Configuration.Types;

namespace Hylasoft.Logging.Configuration.Interfaces.Base
{
  /// <summary>
  /// Configuration values for IResultLoggers.
  /// </summary>
  public interface IResultLoggingConfig
  {
    /// <summary>
    /// The unique id of an instance of the logger.
    /// </summary>
    string LogId { get; }

    /// <summary>
    /// The minimum level of issues to log.
    /// </summary>
    LoggingLevels? Level { get; }

    /// <summary>
    /// Behavior to log the full verbose message of any results that fail.
    /// </summary>
    bool? VerboseOnError { get; }
  }
} 
