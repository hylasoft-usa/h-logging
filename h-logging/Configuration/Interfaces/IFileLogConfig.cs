using Hylasoft.Logging.Configuration.Interfaces.Base;

namespace Hylasoft.Logging.Configuration.Interfaces
{
  public interface IFileLogConfig : IResultMessageLogConfig
  {
    string LogName { get; }

    int? MaxLogFiles { get; }
  }
}
