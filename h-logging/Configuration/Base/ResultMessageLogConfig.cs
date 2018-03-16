using Hylasoft.Logging.Configuration.Interfaces.Base;
using Hylasoft.Logging.Configuration.Types;
using ConfigDefaults = Hylasoft.Logging.Constants.ConfigurationDefaults.Messages;

namespace Hylasoft.Logging.Configuration.Base
{
  public abstract class ResultMessageLogConfig : ResultLoggingConfig, IResultMessageLogConfig
  {
    public string TimestampFormat { get; set; }

    public LoggingDecorations? Decorations { get; set; }

    protected ResultMessageLogConfig(string id = null) : base(id)
    {
      TimestampFormat = ConfigDefaults.TimestampFormat;
      Decorations = ConfigDefaults.Decorations;
    }
  }
}
