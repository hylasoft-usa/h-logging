using Hylasoft.Logging.Configuration;
using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Configuration.Types;

namespace Hylasoft.Logging.Console
{
  public class FileConfig : IFileLogConfig
  {
    public LoggingLevels? Level { get; set; }
    public LoggingDecorations? Decorations { get; set; }
    public bool? VerboseOnError { get; set; }
    public string LogName { get; set; }
    public string LogLocation { get; set; }
    public int? MaxLogFiles { get; set; }
    public string TimestampFormat { get; set; }
  }
}
