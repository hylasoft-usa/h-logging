namespace Hylasoft.Logging.Configuration.Base
{
  public interface IHLoggingConfig
  {
    HLoggingLevels? Level { get; }

    HLoggingDecorations? Decorations { get; }

    bool? VerboseOnError { get; }
  }
} 
