namespace Hylasoft.Logging.Constants
{
  internal static class ConfigurationDefaults
  {
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
