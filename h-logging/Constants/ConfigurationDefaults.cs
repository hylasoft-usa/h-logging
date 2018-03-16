using Hylasoft.Logging.Configuration;

namespace Hylasoft.Logging.Constants
{
  internal static class ConfigurationDefaults
  {
    public const bool VerboseOnError = true;

    public const HLoggingLevels Level = HLoggingLevels.Standard;

    public const HLoggingDecorations Decorations = HLoggingDecorations.All;

    internal static class Messages
    {
      public const string TimestampFormat = "HH:mm:ss";

      public static class File
      {
        public const string FileTargetName = "h-logging";

        public const string LogName = "h-log";

        public const int MaxLogFiles = 7;
      }
    }
  }
}
