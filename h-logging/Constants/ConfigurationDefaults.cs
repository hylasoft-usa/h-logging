using Hylasoft.Logging.Configuration;

namespace Hylasoft.Logging.Constants
{
  internal static class ConfigurationDefaults
  {
    public const bool VerboseOnError = true;

    public const HLoggingLevels Level = HLoggingLevels.Standard;

    internal static class Messages
    {
      public const string TimestampFormat = "HH:mm:ss";
      
      public const HLoggingDecorations Decorations = HLoggingDecorations.All;

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
