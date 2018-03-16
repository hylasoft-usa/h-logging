namespace Hylasoft.Logging.Configuration.Interfaces.Base
{
  public interface IResultLoggingConfig
  {
    HLoggingLevels? Level { get; }

    bool? VerboseOnError { get; }
  }
} 
