using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Configuration.Interfaces.Base;
using Hylasoft.Logging.Loggers.Interfaces;

namespace Hylasoft.Logging.Factories
{
  /// <summary>
  /// Factory for building loggers.
  /// </summary>
  public interface IResultLoggingFactory
  {
    /// <summary>
    /// Constructs a file logger.
    /// </summary>
    /// <param name="configuration">File logger configuration.</param>
    IFileLogger BuildFileLogger(IFileLogConfig configuration);

    /// <summary>
    /// Constructs a console logger.
    /// </summary>
    /// <param name="configuration">Console logger configuration.</param>
    IConsoleLogger BuildConsoleLogger(IConsoleLogConfig configuration);

    /// <summary>
    /// Constructs a logging collection.
    /// </summary>
    /// <param name="configuration">Logging collection configuration.</param>
    ILoggingCollection BuildCollection(IResultLoggingConfig configuration);
  }
}
