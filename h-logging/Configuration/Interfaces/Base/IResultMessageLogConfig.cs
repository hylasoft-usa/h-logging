using Hylasoft.Logging.Configuration.Types;

namespace Hylasoft.Logging.Configuration.Interfaces.Base
{
  /// <summary>
  /// Configuration values for ResultMessageLoggers.
  /// </summary>
  public interface IResultMessageLogConfig : IResultLoggingConfig
  {
    /// <summary>
    /// The Date.Format value for written timestamps.
    /// </summary>
    string TimestampFormat { get; }

    /// <summary>
    /// The decoration options for written issues.
    /// </summary>
    LoggingDecorations? Decorations { get; }
  }
}
