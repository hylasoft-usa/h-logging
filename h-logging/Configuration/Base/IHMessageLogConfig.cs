namespace Hylasoft.Logging.Configuration.Base
{
  public interface IHMessageLogConfig : IHLoggingConfig
  {
    string TimestampFormat { get; }
  }
}
