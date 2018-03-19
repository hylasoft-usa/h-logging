using System;
using Hylasoft.Logging.Configuration.Interfaces.Base;
using Hylasoft.Logging.Configuration.Types;
using Hylasoft.Logging.Constants;

namespace Hylasoft.Logging.Configuration.Base
{
  public abstract class ResultLoggingConfig : IResultLoggingConfig
  {
    public string LogId { get; private set; }

    public LoggingLevels? Level { get; set; }

    public bool? VerboseOnError { get; set; }

    protected ResultLoggingConfig(string id = null)
    {
      Level = ConfigurationDefaults.Level;
      VerboseOnError = ConfigurationDefaults.VerboseOnError;
      LogId = id ?? Guid.NewGuid().ToString();
    }
  }
}
