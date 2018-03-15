using Hylasoft.Logging.Configuration;

namespace Hylasoft.Logging.Console
{
  public class LoggingConfig : IHConsoleLogConfiguration
  {
    public HLoggingLevels Level { get; set; }

    public HLoggingDecorations Decorations { get; set; }

    public string TimestampFormat { get; set; }

    public LoggingConfig()
    {
      Level = HLoggingLevels.Standard;
      TimestampFormat = null;
      Decorations = HLoggingDecorations.All;
    }
  }
}
