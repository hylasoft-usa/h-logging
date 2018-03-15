using Hylasoft.Logging.Configuration;

namespace Hylasoft.Logging.Console
{
  public class FileConfig : IHFileLogConfiguration
  {
    public HLoggingLevels Level { get; set; }
    public HLoggingDecorations Decorations { get; set; }
    public string LogName { get; set; }
    public int? MaxLogFiles { get; set; }
  }
}
