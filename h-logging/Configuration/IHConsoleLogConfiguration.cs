namespace Hylasoft.Logging.Configuration
{
  public interface IHConsoleLogConfiguration : IHLoggingConfiguration
  {
    string TimestampFormat { get; }
  }
}
