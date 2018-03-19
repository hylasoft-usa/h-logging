using System;
using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Configuration.Interfaces.Base;
using Hylasoft.Logging.Loggers.Interfaces;
using OmniColour.Writers;

namespace Hylasoft.Logging.Factories
{
  /// <summary>
  /// A set of overridable constructors for building loggers.
  /// </summary>
  public interface IResultLoggingIoc
  {
    /// <summary>
    /// Defines the constructor for building IColourWriters.
    /// </summary>
    Func<IColourWriter> ColourWriter { set; }

    /// <summary>
    /// Defines the constructor for building IConsoleLoggers.
    /// </summary>
    Func<IConsoleLogConfig, IConsoleLogger> ConsoleLogger { set; }

    /// <summary>
    /// Defines the constructor for building IFileLoggers.
    /// </summary>
    Func<IFileLogConfig, IFileLogger> FileLogger { set; }

    /// <summary>
    /// Defines the constructor for build ILoggingCollections.
    /// </summary>
    Func<IResultLoggingConfig, ILoggingCollection> LoggingCollection { set; } 
  }
}
