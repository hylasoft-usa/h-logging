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
    /// <param name="format">A format string, following String.Format().</param>
    /// <param name="parameters">Parameters to pass to the format string.</param>
    public new static LoggingResult SingleTrace(string format, params object[] parameters)
    {
      return SingleTrace(LoggingIssue.NonIssueCode, format, parameters);
    }

    /// <summary>
    /// Builds a single trace logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="format">A format string, following String.Format().</param>
    /// <param name="parameters">Parameters to pass to the format string.</param>
    public new static LoggingResult SingleTrace(long issueCode, string format, params object[] parameters)
    {
      return SingleResult(ResultIssueLevels.Trace, issueCode, format, parameters);
    }

    /// <summary>
    /// Builds a single trace logging message.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    public static LoggingResult SingleTrace(IColourMessage message)
    {
      return SingleTrace(LoggingIssue.NonIssueCode, message);
    }

    /// <summary>
    /// Builds a single trace logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="message">Message to be logged.</param>
    public static LoggingResult SingleTrace(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Trace, issueCode, message);
    }

    /// <summary>
    /// Builds a single debug logging message.
    /// </summary>
    /// <param name="format">A format string, following String.Format().</param>
    /// <param name="parameters">Parameters to pass to the format string.</param>
    public new static LoggingResult SingleDebug(string format, params object[] parameters)
    {
      return SingleDebug(LoggingIssue.NonIssueCode, format, parameters);
    }

    /// <summary>
    /// Builds a single debug logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="format">A format string, following String.Format().</param>
    /// <param name="parameters">Parameters to pass to the format string.</param>
    public new static LoggingResult SingleDebug(long issueCode, string format, params object[] parameters)
    {
      return SingleResult(ResultIssueLevels.Debug, issueCode, format, parameters);
    }

    /// <summary>
    /// Builds a single debug logging message.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    public static LoggingResult SingleDebug(IColourMessage message)
    {
      return SingleDebug(LoggingIssue.NonIssueCode, message);
    }

    /// <summary>
    /// Builds a single debug logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="message">Message to be logged.</param>
    public static LoggingResult SingleDebug(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Debug, issueCode, message);
    }

    /// <summary>
    /// Builds a single info logging message.
    /// </summary>
    /// <param name="format">A format string, following String.Format().</param>
    /// <param name="parameters">Parameters to pass to the format string.</param>
    public new static LoggingResult SingleInfo(string format, params object[] parameters)
    {
      return SingleInfo(LoggingIssue.NonIssueCode, format, parameters);
    }

    /// <summary>
    /// Builds a single info logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="format">A format string, following String.Format().</param>
    /// <param name="parameters">Parameters to pass to the format string.</param>
    public new static LoggingResult SingleInfo(long issueCode, string format, params object[] parameters)
    {
      return SingleResult(ResultIssueLevels.Info, issueCode, format, parameters);
    }

    /// <summary>
    /// Builds a single info logging message.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    public static LoggingResult SingleInfo(IColourMessage message)
    {
      return SingleInfo(LoggingIssue.NonIssueCode, message);
    }

    /// <summary>
    /// Builds a single info logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="message">Message to be logged.</param>
    public static LoggingResult SingleInfo(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Info, issueCode, message);
    }

    /// <summary>
    /// Builds a single warning logging message.
    /// </summary>
    /// <param name="format">A format string, following String.Format().</param>
    /// <param name="parameters">Parameters to pass to the format string.</param>
    public new static LoggingResult SingleWarning(string format, params object[] parameters)
    {
      return SingleWarning(LoggingIssue.NonIssueCode, format, parameters);
    }

    /// <summary>
    /// Builds a single warning logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="format">A format string, following String.Format().</param>
    /// <param name="parameters">Parameters to pass to the format string.</param>
    public new static LoggingResult SingleWarning(long issueCode, string format, params object[] parameters)
    {
      return SingleResult(ResultIssueLevels.Warning, issueCode, format, parameters);
    }

    /// <summary>
    /// Builds a single warning logging message.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    public static LoggingResult SingleWarning(IColourMessage message)
    {
      return SingleWarning(LoggingIssue.NonIssueCode, message);
    }

    /// <summary>
    /// Builds a single warning logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="message">Message to be logged.</param>
    public static LoggingResult SingleWarning(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Warning, issueCode, message);
    }

    /// <summary>
    /// Builds a single error logging message.
    /// </summary>
    /// <param name="format">A format string, following String.Format().</param>
    /// <param name="parameters">Parameters to pass to the format string.</param>
    public new static LoggingResult SingleError(string format, params object[] parameters)
    {
      return SingleError(LoggingIssue.NonIssueCode, format, parameters);
    }

    /// <summary>
    /// Builds a single error logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="format">A format string, following String.Format().</param>
    /// <param name="parameters">Parameters to pass to the format string.</param>
    public new static LoggingResult SingleError(long issueCode, string format, params object[] parameters)
    {
      return SingleResult(ResultIssueLevels.Error, issueCode, format, parameters);
    }

    /// <summary>
    /// Builds a single error logging message.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    public static LoggingResult SingleError(IColourMessage message)
    {
      return SingleError(LoggingIssue.NonIssueCode, message);
    }

    /// <summary>
    /// Builds a single error logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="message">Message to be logged.</param>
    public static LoggingResult SingleError(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Error, issueCode, message);
    }

    /// <summary>
    /// Builds a single fatal logging message.
    /// </summary>
    /// <param name="format">A format string, following String.Format().</param>
    /// <param name="parameters">Parameters to pass to the format string.</param>
    public new static LoggingResult SingleFatal(string format, params object[] parameters)
    {
      return SingleFatal(LoggingIssue.NonIssueCode, format, parameters);
    }

    /// <summary>
    /// Builds a single fatal logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="format">A format string, following String.Format().</param>
    /// <param name="parameters">Parameters to pass to the format string.</param>
    public new static LoggingResult SingleFatal(long issueCode, string format, params object[] parameters)
    {
      return SingleResult(ResultIssueLevels.Fatal, issueCode, format, parameters);
    }

    /// <summary>
    /// Builds a single fatal logging message.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    public static LoggingResult SingleFatal(IColourMessage message)
    {
      return SingleFatal(LoggingIssue.NonIssueCode, message);
    }

    /// <summary>
    /// Builds a single fatal logging message.
    /// </summary>
    /// <param name="issueCode">Issue code associated with message.</param>
    /// <param name="message">Message to be logged.</param>
    public static LoggingResult SingleFatal(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Fatal, issueCode, message);
    }

    protected static LoggingResult SingleResult(ResultIssueLevels level, long issueCode, string format,
      params object[] parameters)
    {
      string message;
      try
      {
        message = string.Format(format, parameters);
      }
      catch
      {
        message = format;
      }

      return SingleResult(level, issueCode, message);
    }

    protected static LoggingResult SingleResult(ResultIssueLevels level, long issueCode, string message)
    {
      return SingleResult(level, issueCode, HLogging.Message.Append(message));
    }

    protected static LoggingResult SingleResult(ResultIssueLevels level, long issueCode, IColourMessage message)
    {
      return new LoggingResult(new LoggingIssue(message, level, issueCode));
    }
  }
}
