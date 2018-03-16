using System;
using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Loggers.Base;
using Hylasoft.Logging.Loggers.Interfaces;
using Hylasoft.Resolution;
using NLog;
using NLog.Config;
using NLog.Targets;
using OmniColour.Messages;

using ConfigDefaults = Hylasoft.Logging.Constants.ConfigurationDefaults.Messages.File;

namespace Hylasoft.Logging.Loggers
{
  public class FileLogger : ResultMessageLogger<IFileLogConfig>, IFileLogger
  {
    private readonly LogFactory _logFactory;
    private readonly LoggingConfiguration _logConfig;
    private readonly Logger _log;
    private readonly string _logName;

    protected LogFactory LogFactory { get { return _logFactory; } }

    protected LoggingConfiguration LogConfig { get { return _logConfig; } }

    protected Logger Log { get { return _log; } }

    protected string LogName { get { return _logName; } }

    public FileLogger(IFileLogConfig config)
      : base(config)
    {
      _logName = ConfigDefaults.FileTargetName;
      _logConfig = BuildNlogConfiguration();
      _logFactory = new LogFactory(LogConfig);
      _log = LogFactory.GetLogger(LogName);
    }

    protected override Result LogMessage(IColourMessage message)
    {
      try
      {
        var contents = message.BuildRaw();
        Log.Log(LogLevel.Info, contents.Substring(0, contents.LastIndexOf(Environment.NewLine, StringComparison.Ordinal)));
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

    #region Logging Configuration
    private LoggingConfiguration BuildNlogConfiguration()
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
