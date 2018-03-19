using System.Collections.Generic;
using Hylasoft.Resolution;

namespace Hylasoft.Logging.Loggers.Interfaces
{
  /// <summary>
  /// A collection of logs, that allows for printing to multiple sources.
  /// </summary>
  public interface ILoggingCollection : IResultLogger, IEnumerable<IResultLogger>
  {
    /// <summary>
    /// Adds a variable number of loggers to the collection.
    /// </summary>
    /// <param name="loggers">Loggers to add.</param>
    Result Add(params IResultLogger[] loggers);

    /// <summary>
    /// Adds an enumeration of loggers to the collection.
    /// </summary>
    /// <param name="loggers">Loggers to add.</param>
    Result Add(IEnumerable<IResultLogger> loggers);

    /// <summary>
    /// Adds a single logger to the collection.
    /// </summary>
    /// <param name="logger">Logger to add.</param>
    Result Add(IResultLogger logger);

    /// <summary>
    /// Removes a logger from the collection.
    /// </summary>
    /// <param name="logId">Id of the logger to remove.</param>
    Result Remove(string logId);
  }
}
