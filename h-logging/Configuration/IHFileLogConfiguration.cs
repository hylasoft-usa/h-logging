namespace Hylasoft.Logging.Configuration
{
  public interface IHFileLogConfiguration : IHLoggingConfiguration
  {
    string LogName { get; }

    int? MaxLogFiles { get; }
  }
}
