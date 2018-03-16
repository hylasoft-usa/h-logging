namespace Hylasoft.Logging.Configuration
{
  public interface IHLoggingConfig
  {
    HLoggingLevels Level { get; }

    HLoggingDecorations Decorations { get; }
  }
} 
