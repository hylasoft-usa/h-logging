using System;

namespace Hylasoft.Logging.Configuration.Types
{
  /// <summary>
  /// A set of decoration options for writing issues.
  /// </summary>
  [Flags]
  public enum LoggingDecorations
  {
    /// <summary>
    /// Keep all default decorations.
    /// </summary>
    All = 0x0,

    /// <summary>
    /// Ommit the timestamp section.
    /// </summary>
    OmmitDate = 0x1,

    /// <summary>
    /// Ommit the issue level.
    /// </summary>
    OmmitIssueLevel = 0x2,

    /// <summary>
    /// Display only the message.
    /// </summary>
    Minimal = OmmitDate | OmmitIssueLevel,

    /// <summary>
    /// Ommit all colour.
    /// </summary>
    OmmitColour = 0x4,

    /// <summary>
    /// Display only the message, without colour.
    /// </summary>
    LifeLess = Minimal | OmmitColour
  }
}
