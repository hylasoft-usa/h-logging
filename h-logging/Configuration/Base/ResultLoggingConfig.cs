using Hylasoft.Logging.Configuration.Interfaces.Base;
using Hylasoft.Logging.Configuration.Types;
using Hylasoft.Logging.Constants;

namespace Hylasoft.Logging.Configuration.Base
{
  public abstract class ResultLoggingConfig : IResultLoggingConfig
  {
    public LoggingLevels? Level { get; set; }

    public bool? VerboseOnError { get; set; }

    protected ResultLoggingConfig()
    {
      Level = ConfigurationDefaults.Level;
      VerboseOnError = ConfigurationDefaults.VerboseOnError;
    }
  }
}
