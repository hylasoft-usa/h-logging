namespace Hylasoft.Logging.Configuration.Interfaces.Base
{
  public interface IResultLoggingConfig
  {
    HLoggingLevels? Level { get; }

    HLoggingDecorations? Decorations { get; }

    bool? VerboseOnError { get; }
  }
} 
