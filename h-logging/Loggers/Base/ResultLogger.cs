using System;
using System.Linq;
using System.Threading;
using Hylasoft.Logging.Configuration.Interfaces.Base;
using Hylasoft.Logging.Configuration.Types;
using Hylasoft.Logging.Resolution;
using Hylasoft.Logging.Resources;
using Hylasoft.Resolution;

using ConfigDefaults = Hylasoft.Logging.Constants.ConfigurationDefaults;

namespace Hylasoft.Logging.Loggers.Base
{
  /// <summary>
  /// A class that is able to log Results in some way.
  /// </summary>
  public abstract class ResultLogger<TConfig> : IResultLogger
    where TConfig : IResultLoggingConfig
  {
    private readonly TConfig _config;
    private readonly string _id;

    private TConfig Config { get { return _config; } }

    protected ResultLogger(TConfig config)
    {
      _config = config;
      _id = ReadConfig(c => c.LogId, Guid.NewGuid().ToString());
    }

    /// <summary>
    /// The unique id associated with an instance of the logger.
    /// Will be set to a GUID, if left unspecified.
    /// </summary>
    public string Id { get { return _id; } }

    /// <summary>
    /// Logs a Result in a new thread.
    /// </summary>
    /// <param name="result">Result to be logged.</param>
    public Result Log(Result result)
    {
      return Log(result, LogAsync);
    }

    /// <summary>
    /// Logs a Result in the current thread.
    /// </summary>
    /// <param name="result">Result to be logged.</param>
    public Result LogSynchronous(Result result)
    {
      return Log(result, LogIssues);
    }

    public Result Log(Result result, Func<ResultIssue[], Result> log)
    {
      try
      {
        if (result == null)
          return Result.SingleWarning(Warnings.NothingToLog);

        // Get appropriate filter.
        var filter = IsStandard
          ? IsStandardMessage
          : IsVerbose
            ? IsVerboseMessage
            : (Func<ResultIssue, bool>) IsQuietMessage;

        // Implement VerboseOnError.
        var verboseOnError = ReadConfig(c => c.VerboseOnError, ConfigDefaults.VerboseOnError) ?? ConfigDefaults.VerboseOnError;
        if (verboseOnError && !result)
          filter = IsVerboseMessage;

        var message = result.Issues.Where(filter).ToArray();
        return result + log(message);
      }
      catch (Exception e)
      {
        return result + Result.Error(e);
      }
    }

    protected virtual bool IsVerboseMessage(ResultIssue issue)
    {
      return issue != null;
    }

    protected virtual bool IsStandardMessage(ResultIssue issue)
    {
      return IsVerboseMessage(issue) && issue.Level >= ResultIssueLevels.Info;
    }

    protected virtual bool IsQuietMessage(ResultIssue issue)
    {
      return IsVerboseMessage(issue) && (issue is LoggingIssue || issue.Level >= ResultIssueLevels.Warning);
    }

    protected Result LogAsync(ResultIssue[] issues)
    {
      var task = new Thread(() => LogIssues(issues));
      task.Start();

      return Result.Success;
    }

    protected abstract Result LogIssues(ResultIssue[] issues);

    protected bool IsVerbose { get { return ReadConfig(c => c.Level, ConfigDefaults.Level) == LoggingLevels.Verbose; } }

    protected bool IsQuiet { get { return ReadConfig(c => c.Level, ConfigDefaults.Level) == LoggingLevels.Quiet; } }

    protected bool IsStandard { get { return !IsVerbose && !IsQuiet; } }

    protected TValue ReadConfig<TValue>(Func<TConfig, TValue> read, TValue defaultValue)
    {
      TValue readValue;
      return ReferenceEquals(Config, null) || ReferenceEquals(readValue = read(Config), null)
        ? defaultValue
        : readValue;
    }

    protected string ReadConfig(Func<TConfig, string> read, string defaultValue)
    {
      string readValue;
      return string.IsNullOrEmpty(readValue = ReadConfig<string>(read, defaultValue))
        ? defaultValue
        : readValue;
    }
  }
}
