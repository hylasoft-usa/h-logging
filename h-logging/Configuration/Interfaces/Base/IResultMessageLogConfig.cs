using Hylasoft.Logging.Configuration.Types;

namespace Hylasoft.Logging.Configuration.Interfaces.Base
{
  public interface IResultMessageLogConfig : IResultLoggingConfig
  {
    string TimestampFormat { get; }

    LoggingDecorations? Decorations { get; }
  }
}
