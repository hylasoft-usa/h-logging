using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Factories;
using Hylasoft.Logging.Loggers.Interfaces;

namespace Hylasoft.Logging
{
  public static class HLogging
  {
    public static IResultLoggingFactory Factory { private get; set; }

    static HLogging()
    {
      Factory = new ResultLoggingFactory();
    }

    public static IFileLogger FileLogger(IFileLogConfig configuration)
    {
      return Factory.BuildFileLogger(configuration);
    }

    public static IConsoleLogger ConsoleLogger(IConsoleLogConfig configuration)
    {
      return Factory.BuildConsoleLogger(configuration);
    }

    public static IResultLoggingIoc Ioc 
    {
      get { return Factory as IResultLoggingIoc; } 
    }
  }
}
