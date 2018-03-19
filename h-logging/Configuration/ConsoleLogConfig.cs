using Hylasoft.Logging.Configuration.Base;
using Hylasoft.Logging.Configuration.Interfaces;

namespace Hylasoft.Logging.Configuration
{
  /// <summary>
  /// A usable configuration for IConsoleLoggers.
  /// </summary>
  public class ConsoleLogConfig : ResultMessageLogConfig, IConsoleLogConfig
  {
    public ConsoleLogConfig(string id = null) : base(id)
    {
    }
  }
}
