using Hylasoft.Logging.Configuration.Interfaces.Base;

namespace Hylasoft.Logging.Configuration.Interfaces
{
  /// <summary>
  /// Configuration values for IFileLoggers.
  /// </summary>
  public interface IFileLogConfig : IResultMessageLogConfig
  {
    /// <summary>
    /// Name of the log file.
    /// </summary>
    string LogName { get; }

    /// <summary>
    /// Location of the log file.
    /// </summary>
    string LogLocation { get; }

    /// <summary>
    /// Maximum number of log files.
    /// A new file is created for each day.
    /// </summary>
    int? MaxLogFiles { get; }
  }
}
