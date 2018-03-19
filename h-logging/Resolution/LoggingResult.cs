using System.Collections.Generic;
using Hylasoft.Resolution;
using OmniColour.Messages;

namespace Hylasoft.Logging.Resolution
{
  /// <summary>
  /// A specialized Result, designed for storing logging messages.
  /// </summary>
  public class LoggingResult : Result
  {
    protected LoggingResult(ResultIssue issue) : base(issue)
    {
    }

    protected LoggingResult(IEnumerable<ResultIssue> issues) : base(issues)
    {
    }

    /// <summary>
    /// Builds a Result from an enumeration of issues.
    /// </summary>
    internal static Result FromIssues(IEnumerable<ResultIssue> issues)
    {
      return new LoggingResult(issues);
    }

    /// <summary>
    /// Builds a single trace logging message.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    public static Result SingleTrace(IColourMessage message)
    {
      return SingleTrace(LoggingIssue.NonIssueCode, message);
    }

    /// <summary>
    /// Builds a single trace logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="message">Message to be logged.</param>
    public static Result SingleTrace(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Trace, issueCode, message);
    }

    /// <summary>
    /// Builds a single debug logging message.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    public static Result SingleDebug(IColourMessage message)
    {
      return SingleDebug(LoggingIssue.NonIssueCode, message);
    }

    /// <summary>
    /// Builds a single debug logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="message">Message to be logged.</param>
    public static Result SingleDebug(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Debug, issueCode, message);
    }

    /// <summary>
    /// Builds a single info logging message.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    public static Result SingleInfo(IColourMessage message)
    {
      return SingleInfo(LoggingIssue.NonIssueCode, message);
    }

    /// <summary>
    /// Builds a single info logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="message">Message to be logged.</param>
    public static Result SingleInfo(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Info, issueCode, message);
    }

    /// <summary>
    /// Builds a single warning logging message.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    public static Result SingleWarning(IColourMessage message)
    {
      return SingleWarning(LoggingIssue.NonIssueCode, message);
    }

    /// <summary>
    /// Builds a single warning logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="message">Message to be logged.</param>
    public static Result SingleWarning(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Warning, issueCode, message);
    }

    /// <summary>
    /// Builds a single error logging message.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    public static Result SingleError(IColourMessage message)
    {
      return SingleError(LoggingIssue.NonIssueCode, message);
    }

    /// <summary>
    /// Builds a single error logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="message">Message to be logged.</param>
    public static Result SingleError(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Error, issueCode, message);
    }

    /// <summary>
    /// Builds a single fatal logging message.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    public static Result SingleFatal(IColourMessage message)
    {
      return SingleFatal(LoggingIssue.NonIssueCode, message);
    }

    /// <summary>
    /// Builds a single fatal logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="message">Message to be logged.</param>
    public static Result SingleFatal(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Fatal, issueCode, message);
    }

    protected static Result SingleResult(ResultIssueLevels level, long issueCode, IColourMessage message)
    {
      return new LoggingResult(new LoggingIssue(message, level, issueCode));
    }
  }
}
