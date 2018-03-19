using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Hylasoft.Logging.Configuration.Interfaces.Base;
using Hylasoft.Logging.Loggers.Base;
using Hylasoft.Logging.Loggers.Interfaces;
using Hylasoft.Logging.Resolution;
using Hylasoft.Logging.Resources;
using Hylasoft.Resolution;

namespace Hylasoft.Logging.Loggers
{
  public class LoggingCollection : ResultLogger<IResultLoggingConfig>, ILoggingCollection
  {
    private readonly Dictionary<string, IResultLogger> _loggers;

    protected IDictionary<string, IResultLogger> LoggerSet { get { return _loggers; } }

    protected ICollection<IResultLogger> Loggers { get { return LoggerSet.Values; } } 

    public LoggingCollection(IResultLoggingConfig config = null) : base(config)
    {
      _loggers = new Dictionary<string, IResultLogger>();
    }

    protected override Result LogIssues(ResultIssue[] issues)
    {
      return Loggers.Aggregate(Result.Success, (r, l) => r + l.LogSynchronous(LoggingResult.FromIssues(issues)));
    }

    public IEnumerator<IResultLogger> GetEnumerator()
    {
      return Loggers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public Result Add(params IResultLogger[] loggers)
    {
      return Add((IEnumerable<IResultLogger>) loggers);
    }

    public Result Add(IEnumerable<IResultLogger> loggers)
    {
      return loggers == null
        ? Result.SingleError(Errors.AddingNullLoggerToCollection)
        : loggers.Aggregate(Result.Success, (r, l) => Add(l));
    }

    public Result Add(IResultLogger logger)
    {
      if (ReferenceEquals(logger, null))
        return Result.SingleError(Errors.AddingNullLoggerToCollection);

      try
      {
        var key = logger.Id;
        if (LoggerSet.ContainsKey(key))
          return Result.SingleWarning(Warnings.LoggerAlreadyExists, key);

        LoggerSet.Add(key, logger);
        return Result.Success;
      }
      catch (Exception e)
      {
        return Result.Error(e);
      }
    }

    public Result Remove(string logId)
    {
      try
      {
        if (string.IsNullOrEmpty(logId) || !LoggerSet.ContainsKey(logId))
          return Result.SingleWarning(Warnings.LoggerDoesNotExist, logId);

        LoggerSet.Remove(logId);
        return Result.Success;
      }
      catch (Exception e)
      {
        return Result.Error(e);
      }
    }
  }
}
