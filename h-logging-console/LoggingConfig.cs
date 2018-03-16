using Hylasoft.Logging.Configuration;
using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Configuration.Types;

namespace Hylasoft.Logging.Console
{
  public class LoggingConfig : IConsoleLogConfig
  {
    public LoggingLevels? Level { get; set; }

    public LoggingDecorations? Decorations { get; set; }
    
    public bool? VerboseOnError { get; set; }

    public string TimestampFormat { get; set; }

    public LoggingConfig()
    {
      Level = LoggingLevels.Standard;
      TimestampFormat = null;
      Decorations = LoggingDecorations.All;
    }
  }
}
