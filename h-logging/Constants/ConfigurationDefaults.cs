namespace Hylasoft.Logging.Constants
{
  public static class ConfigurationDefaults
  {
    public static class File
    {
      public const string FileTargetName = "h-logging";

      public const string LogName = "h-log";
      
      public const int MaxLogFiles = 7;
    }

    public static class Console
    {
      public const string TimestampFormat = "HH:mm:ss";

    }
  }
}
