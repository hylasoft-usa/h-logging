using Hylasoft.Resolution;

namespace Hylasoft.Logging
{
  /// <summary>
  /// A class that is able to log Results in some way.
  /// </summary>
  public interface IResultLogger
  {
    /// <summary>
    /// The unique id associated with an instance of the logger.
    /// Will be set to a GUID, if left unspecified.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Logs a Result in a new thread.
    /// </summary>
    /// <param name="result">Result to be logged.</param>
    Result Log(Result result);

    /// <summary>
    /// Logs a Result in the current thread.
    /// </summary>
    /// <param name="result">Result to be logged.</param>
    Result LogSynchronous(Result result);
  }
}
