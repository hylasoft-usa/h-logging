using System;
using Hylasoft.Logging.Configuration.Interfaces.Base;
using Hylasoft.Logging.Configuration.Types;
using Hylasoft.Logging.Constants;

namespace Hylasoft.Logging.Configuration.Base
{
  /// <summary>
  /// Configuration values for IResultLoggers.
  /// </summary>
  public abstract class ResultLoggingConfig : IResultLoggingConfig
  {
    /// <summary>
    /// The unique id of an instance of the logger.
    /// </summary>
    public string LogId { get; private set; }

    /// <summary>
    /// The minimum level of issues to log.
    /// </summary>
    public LoggingLevels? Level { get; set; }

    /// <summary>
    /// Behavior to log the full verbose message of any results that fail.
    /// </summary>
    public bool? VerboseOnError { get; set; }

    protected ResultLoggingConfig(string id = null)
    {
      Level = ConfigurationDefaults.Level;
      VerboseOnError = ConfigurationDefaults.VerboseOnError;
      LogId = id ?? Guid.NewGuid().ToString();
    }
  }
}
