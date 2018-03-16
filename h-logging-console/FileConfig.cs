using Hylasoft.Logging.Configuration;
using Hylasoft.Logging.Configuration.Interfaces;

namespace Hylasoft.Logging.Console
{
  public class FileConfig : IFileLogConfig
  {
    public HLoggingLevels? Level { get; set; }
    public HLoggingDecorations? Decorations { get; set; }
    public bool? VerboseOnError { get; set; }
    public string LogName { get; set; }
    public string LogLocation { get; set; }
    public int? MaxLogFiles { get; set; }
    public string TimestampFormat { get; set; }
  }
}
