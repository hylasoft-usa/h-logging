using System;
using System.IO;
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
  /// <summary>
  /// A logger that writes to files.
  /// </summary>
  public class FileLogger : ResultMessageLogger<IFileLogConfig>, IFileLogger
  {
    private readonly LogFactory _logFactory;
    private readonly LoggingConfiguration _logConfig;
    private readonly Logger _log;

    protected LogFactory LogFactory { get { return _logFactory; } }

    protected LoggingConfiguration LogConfig { get { return _logConfig; } }

    protected Logger NLog { get { return _log; } }

    protected internal FileLogger(IFileLogConfig config)
      : base(config)
    {
      _logConfig = BuildNlogConfiguration();
      _logFactory = new LogFactory(LogConfig);
      _log = LogFactory.GetLogger(Id);
    }

    protected override Result LogMessage(IColourMessage message)
    {
      try
      {
        var contents = message.BuildRaw();
        NLog.Log(LogLevel.Info, contents);
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
      const string layout = "${message}";

      var defaultName = string.Format("{0}.log", Id);
      var location = ReadConfig(c => c.LogLocation, ConfigDefaults.LogLocation);
      var logName = ReadConfig(c => c.LogName, defaultName);
      var maxFiles = ReadConfig(c => c.MaxLogFiles, ConfigDefaults.MaxLogFiles) ?? ConfigDefaults.MaxLogFiles;
      var fileName = Path.Combine(location, logName);

      return new FileTarget(Id)
      {
        ReplaceFileContentsOnEachWrite = false,
        Layout = layout,
        ArchiveEvery = FileArchivePeriod.Day,
        FileName = fileName,
        MaxArchiveFiles = maxFiles,
        LineEnding = LineEndingMode.None
      };
    }
    #endregion
  }
}
