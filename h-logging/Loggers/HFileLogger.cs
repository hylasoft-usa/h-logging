using System;
using System.Linq;
using Hylasoft.Logging.Configuration;
using Hylasoft.Logging.Loggers.Base;
using Hylasoft.Logging.Resources;
using Hylasoft.Resolution;
using NLog;
using NLog.Config;
using NLog.Targets;

using ConfigDefaults = Hylasoft.Logging.Constants.ConfigurationDefaults.File;

namespace Hylasoft.Logging.Loggers
{
  public class HFileLogger : HLogger<IHFileLogConfiguration>
  {
    private readonly LogFactory _logFactory;
    private readonly LoggingConfiguration _logConfig;
    private readonly Logger _log;
    private readonly string _logName;

    protected LogFactory LogFactory { get { return _logFactory; } }

    protected LoggingConfiguration LogConfig { get { return _logConfig; } }

    protected Logger Log { get { return _log; } }

    protected string LogName { get { return _logName; } }

    public HFileLogger(IHFileLogConfiguration config) : base(config)
    {
      _logName = ConfigDefaults.FileTargetName;
      _logConfig = ToNlogConfiguration(config);
      _logFactory = new LogFactory(LogConfig);
      _log = LogFactory.GetLogger(LogName);
    }

    protected override Result LogIssues(ResultIssue[] issues)
    {
      return issues == null
        ? Result.SingleWarning(Warnings.NothingToLog)
        : issues.Where(issue => issue != null)
          .Aggregate(Result.Success, (r, i) => r + LogIssue(i));
    }

    protected Result LogIssue(ResultIssue issue)
    {
      try
      {
        var level = ToNlogLevel(issue.Level);
        var message = BuildMessage(issue);

        Log.Log(level, message);
        return Result.Success;
      }
      catch (Exception e)
      {
        return Result.Error(e);
      }
    }

    protected string BuildMessage(ResultIssue issue)
    {
      return issue.Message;
    }

    protected LogLevel ToNlogLevel(ResultIssueLevels level)
    {
      switch (level)
      {
        case ResultIssueLevels.Trace:
          return LogLevel.Trace;

        case ResultIssueLevels.Debug:
          return LogLevel.Debug;

        case ResultIssueLevels.Warning:
          return LogLevel.Warn;

        case ResultIssueLevels.Error:
          return LogLevel.Error;

        case ResultIssueLevels.Fatal:
          return LogLevel.Fatal;

        default:
          return LogLevel.Info;
      }
    }

    #region Logging Configuration
    private LoggingConfiguration ToNlogConfiguration(IHFileLogConfiguration config)
    {
      var nlConfig = new LoggingConfiguration();
      var fileTarget = BuildFileTarget();

      nlConfig.AddTarget(fileTarget);
      nlConfig.AddRule(LogLevel.Trace, LogLevel.Fatal, fileTarget.Name);

      return nlConfig;
    }

    private Target BuildFileTarget()
    {
      const string fileFormat = "${{basedir}}/logs/{0}.log";
      const string layout = "${message}";
      
      var fileName = string.Format(fileFormat, ReadConfig(c => c.LogName, ConfigDefaults.LogName));
      var maxFiles = ReadConfig(c => c.MaxLogFiles, ConfigDefaults.MaxLogFiles) ?? ConfigDefaults.MaxLogFiles;

      return new FileTarget(LogName)
      {
        ReplaceFileContentsOnEachWrite = false,
        Layout = layout,
        ArchiveEvery = FileArchivePeriod.Day,
        FileName = fileName,
        MaxArchiveFiles = maxFiles
      };
    }
    #endregion
  }
}
