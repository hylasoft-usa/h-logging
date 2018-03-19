using Hylasoft.Logging.Configuration.Interfaces.Base;
using Hylasoft.Logging.Configuration.Types;

using ConfigDefaults = Hylasoft.Logging.Constants.ConfigurationDefaults.Messages;

namespace Hylasoft.Logging.Configuration.Base
{
  /// <summary>
  /// Configuration values for ResultMessageLoggers.
  /// </summary>
  public abstract class ResultMessageLogConfig : ResultLoggingConfig, IResultMessageLogConfig
  {
    /// <summary>
    /// The Date.Format value for written timestamps.
    /// </summary>
    public string TimestampFormat { get; set; }

    /// <summary>
    /// The decoration options for written issues.
    /// </summary>
    public LoggingDecorations? Decorations { get; set; }

    protected ResultMessageLogConfig(string id = null) : base(id)
    {
      TimestampFormat = ConfigDefaults.TimestampFormat;
      Decorations = ConfigDefaults.Decorations;
    }
  }
}
