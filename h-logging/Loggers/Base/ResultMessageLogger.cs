using System;
using System.Linq;
using Hylasoft.Logging.Configuration.Interfaces.Base;
using Hylasoft.Logging.Configuration.Types;
using Hylasoft.Logging.Resolution;
using Hylasoft.Logging.Resources;
using Hylasoft.Resolution;
using OmniColour;
using OmniColour.Messages;

using ConfigDefaults = Hylasoft.Logging.Constants.ConfigurationDefaults.Messages;

namespace Hylasoft.Logging.Loggers.Base
{
  /// <summary>
  /// A class that logs Results as text, in some manner.
  /// Results are translated to a single IColourMessage, for logging.
  /// </summary>
  public abstract class ResultMessageLogger<TConfig> : ResultLogger<TConfig>
    where TConfig : IResultMessageLogConfig
  {
    protected ResultMessageLogger(TConfig config) : base(config)
    {
    }

    protected sealed override Result LogIssues(ResultIssue[] issues)
    {
      if (issues == null || !issues.Any())
        return Result.SingleWarning(Warnings.NothingToLog);

      Result log;
      IColourMessage message;
      if (!(log = BuildResultHeader(out message)))
        return log;

      log = issues.Aggregate(log, (r, i) => AppendIssue(message, i));

      return log + LogMessage(message);
    }

    /// <summary>
    /// Logs an IColourMessage.
    /// </summary>
    /// <param name="message">Message to be logged.</param>
    protected abstract Result LogMessage(IColourMessage message);

    protected virtual Result BuildResultHeader(out IColourMessage message)
    {
      message = Colour.Message;
      return Result.Success;
    }

    protected virtual Result AppendIssue(IColourMessage message, ResultIssue issue)
    {
      Result append;
      if (!(append = AppendIssuePrefix(message, issue)))
        return append;

      return append + AppendIssueMessage(message, issue);
    }

    protected virtual Result AppendIssuePrefix(IColourMessage message, ResultIssue issue)
    {
      return AppendTime(message, issue) + AppendLevel(message, issue);
    }

    protected bool HasDecoration(LoggingDecorations decoration)
    {
      var configuredDecorations = ReadConfig(c => c.Decorations, ConfigDefaults.Decorations);
      return (configuredDecorations & decoration) != 0x0;
    }

    protected virtual Result AppendTime(IColourMessage message, ResultIssue issue)
    {
      if (HasDecoration(LoggingDecorations.OmmitDate))
        return Result.Success;

      var format = ReadConfig(c => c.TimestampFormat, ConfigDefaults.TimestampFormat);
      message.AppendFormat("({0}) ", issue.Date.ToString(format));

      return Result.Success;
    }

    protected virtual Result AppendLevel(IColourMessage message, ResultIssue issue)
    {
      if (HasDecoration(LoggingDecorations.OmmitIssueLevel))
        return Result.Success;

      var colour = GetColour(issue.Level);

      message.Append("[");
      message.Append(colour, issue.Level.ToString());

      if (issue.IssueCode > 0)
       message.AppendFormat(": {0}", issue.IssueCode);

      message.Append("] ");

      return Result.Success;
    }

    protected virtual Result AppendIssueMessage(IColourMessage message, ResultIssue issue)
    {
      try
      {
        LoggingIssue logIssue;
        IColourMessage logMessage;
        if ((logIssue = issue as LoggingIssue) == null
            || (logMessage = logIssue.ColourMessage) == null
            || HasDecoration(LoggingDecorations.OmmitColour))
        {
          message.AppendLine(issue.Message);
          return Result.Success;
        }

        message.Append(logMessage);
        return Result.Success;
      }
      catch (Exception e)
      {
        return Result.Error(e);
      }
    }

    protected virtual OmniColours GetColour(ResultIssueLevels level)
    {
      switch (level)
      {
        case ResultIssueLevels.Warning:
          return OmniColours.BrightYellow;

        case ResultIssueLevels.Error:
          return OmniColours.BrightRed;

        case ResultIssueLevels.Fatal:
          return OmniColours.BrightMagenta;

        case ResultIssueLevels.Info:
          return OmniColours.BrightGreen;

        case ResultIssueLevels.Trace:
          return OmniColours.Blue;

        case ResultIssueLevels.Debug:
          return OmniColours.BrightBlue;

        default:
          return OmniColours.White;
      }
    }
  }
}
