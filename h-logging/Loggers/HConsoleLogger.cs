using System;
using System.Linq;
using Hylasoft.Logging.Configuration;
using Hylasoft.Logging.Loggers.Base;
using Hylasoft.Logging.Resources;
using Hylasoft.Resolution;
using OmniColour;
using OmniColour.Messages;
using OmniColour.Writers;

using ConfigDefaults = Hylasoft.Logging.Constants.ConfigurationDefaults.Console;

namespace Hylasoft.Logging.Loggers
{
  public class HConsoleLogger : HLogger<IHConsoleLogConfiguration>
  {
    private readonly IColourWriter _writer;

    protected IColourWriter Writer { get { return _writer; } }

    public HConsoleLogger(IHConsoleLogConfiguration config, IColourWriter writer)
      : base(config)
    {
      _writer = writer;
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

      Writer.Write(message);
      return log;
    }

    protected virtual Result BuildResultHeader(out IColourMessage message)
    {
      message = Writer.Message;
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
      // Don't add prefix to quiet messages.
      if (IsQuiet) return Result.Success;

      return AppendTime(message, issue) + AppendLevel(message, issue);
    }

    protected virtual Result AppendTime(IColourMessage message, ResultIssue issue)
    {
      if (HasDecoration(HLoggingDecorations.OmmitDate))
        return Result.Success;

      var format = ReadConfig(c => c.TimestampFormat, ConfigDefaults.TimestampFormat);
      message.AppendFormat("({0}) ", issue.Date.ToString(format));

      return Result.Success;
    }

    protected virtual Result AppendLevel(IColourMessage message, ResultIssue issue)
    {
      if (HasDecoration(HLoggingDecorations.OmmitIssueLevel))
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
            || HasDecoration(HLoggingDecorations.OmmitColour))
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
