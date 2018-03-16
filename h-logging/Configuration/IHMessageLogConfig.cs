namespace Hylasoft.Logging.Configuration
{
  public interface IHMessageLogConfig : IHLoggingConfig
  {
    string TimestampFormat { get; }
  }
}
