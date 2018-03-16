namespace Hylasoft.Logging.Configuration
{
  public interface IHFileLogConfiguration : IHMessageLogConfiguration
  {
    string LogName { get; }

    int? MaxLogFiles { get; }
  }
}
