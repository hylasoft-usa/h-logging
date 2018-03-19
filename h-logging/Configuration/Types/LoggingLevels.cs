namespace Hylasoft.Logging.Configuration.Types
{
  /// <summary>
  /// Levels of logging verbosity.
  /// </summary>
  public enum LoggingLevels
  {
    /// <summary>
    /// Log only LoggingIssues, or standard issues that are of warning level or higher.
    /// </summary>
    Standard = 0x0,

    /// <summary>
    /// Log all issues.
    /// </summary>
    Verbose = 0x1
  }
}
