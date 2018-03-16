using Hylasoft.Logging.Configuration;
using Hylasoft.Logging.Configuration.Types;

namespace Hylasoft.Logging.Constants
{
  internal static class ConfigurationDefaults
  {
    public const bool VerboseOnError = true;

    public const LoggingLevels Level = LoggingLevels.Standard;

    internal static class Messages
    {
      public const string TimestampFormat = "HH:mm:ss";
      
      public const LoggingDecorations Decorations = LoggingDecorations.All;

      public static class File
      {
        public const string FileTargetName = "h-logging";

        public const string LogName = "h-log.log";

        public const int MaxLogFiles = 7;

        public const string LogLocation = "Logs";
      }
    }
  }
}
