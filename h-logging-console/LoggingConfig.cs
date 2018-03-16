using Hylasoft.Logging.Configuration;
using Hylasoft.Logging.Configuration.Interfaces;

namespace Hylasoft.Logging.Console
{
  public class LoggingConfig : IConsoleLogConfig
  {
    public HLoggingLevels? Level { get; set; }

    public HLoggingDecorations? Decorations { get; set; }
    
    public bool? VerboseOnError { get; set; }

    public string TimestampFormat { get; set; }

    public LoggingConfig()
    {
      Level = HLoggingLevels.Standard;
      TimestampFormat = null;
      Decorations = HLoggingDecorations.All;
    }
  }
}
