using Hylasoft.Logging.Configuration;

namespace Hylasoft.Logging.Console
{
  public class FileConfig : IFileLogConfig
  {
    public HLoggingLevels? Level { get; set; }
    public HLoggingDecorations? Decorations { get; set; }
    public bool? VerboseOnError { get; set; }
    public string LogName { get; set; }
    public int? MaxLogFiles { get; set; }
    public string TimestampFormat { get; set; }
  }
}
