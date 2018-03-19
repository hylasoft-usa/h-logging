using System.Collections;
using System.Collections.Generic;
using Hylasoft.Resolution;
using OmniColour.Messages;

namespace Hylasoft.Logging.Resolution
{
  public class LoggingResult : Result
  {
    protected LoggingResult(ResultIssue issue) : base(issue)
    {
    }

    protected LoggingResult(IEnumerable<ResultIssue> issues) : base(issues)
    {
    }

    public static Result FromIssues(IEnumerable<ResultIssue> issues)
    {
      return new LoggingResult(issues);
    }

    public static Result SingleTrace(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Trace, issueCode, message);
    }

    public static Result SingleDebug(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Debug, issueCode, message);
    }

    public static Result SingleInfo(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Info, issueCode, message);
    }

    public static Result SingleWarning(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Warning, issueCode, message);
    }

    public static Result SingleError(long issueCode, IColourMessage message)
    {
      return SingleResult(ResultIssueLevels.Error, issueCode, message);
    }

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
