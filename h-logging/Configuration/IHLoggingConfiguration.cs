namespace Hylasoft.Logging.Configuration
{
  public interface IHLoggingConfiguration
  {
    HLoggingLevels Level { get; }

    HLoggingDecorations Decorations { get; }
  }
} 
