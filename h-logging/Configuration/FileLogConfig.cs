using Hylasoft.Logging.Configuration.Base;
using Hylasoft.Logging.Configuration.Interfaces;

using ConfigDefaults = Hylasoft.Logging.Constants.ConfigurationDefaults.Messages.File;

namespace Hylasoft.Logging.Configuration
{
  /// <summary>
  /// A usable configuration for IFileLoggers.
  /// </summary>
  public class FileLogConfig : ResultMessageLogConfig, IFileLogConfig
  {
    /// <summary>
    /// Name of the log file.
    /// </summary>
    public string LogName { get; set; }
    
    /// <summary>
    /// Location of the log file.
    /// </summary>
    public string LogLocation { get; set; }

    /// <summary>
    /// Maximum number of log files.
    /// A new file is created for each day.
    /// </summary>
    public int? MaxLogFiles { get; set; }

    public FileLogConfig(string id = null) : base(id)
    {
      LogName = string.Format("{0}.log", LogId);
      LogLocation = ConfigDefaults.LogLocation;
      MaxLogFiles = ConfigDefaults.MaxLogFiles;
    }
  }
}
