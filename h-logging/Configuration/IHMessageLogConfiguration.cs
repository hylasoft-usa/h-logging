namespace Hylasoft.Logging.Configuration
{
  public interface IHMessageLogConfiguration : IHLoggingConfiguration
  {
    string TimestampFormat { get; }
  }
}
