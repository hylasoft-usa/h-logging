using System;

namespace Hylasoft.Logging.Configuration.Types
{
  [Flags]
  public enum LoggingDecorations
  {
    All = 0x0,
    OmmitDate = 0x1,
    OmmitIssueLevel = 0x2,
    Minimal = OmmitDate | OmmitIssueLevel,
    OmmitColour = 0x4,
    LifeLess = Minimal | OmmitColour
  }
}
