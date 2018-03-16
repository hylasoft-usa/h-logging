using Hylasoft.Logging.Configuration.Base;
using Hylasoft.Logging.Configuration.Interfaces;

using ConfigDefaults = Hylasoft.Logging.Constants.ConfigurationDefaults.Messages.File;

namespace Hylasoft.Logging.Configuration
{
  public class FileLogConfig : ResultMessageLogConfig, IFileLogConfig
  {
    public string LogName { get; set; }
    
    public string LogLocation { get; set; }

    public int? MaxLogFiles { get; set; }

    public FileLogConfig()
    {
      LogName = ConfigDefaults.LogName;
      LogLocation = ConfigDefaults.LogLocation;
      MaxLogFiles = ConfigDefaults.MaxLogFiles;
    }
  }
}
