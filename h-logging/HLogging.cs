using System;
using System.Collections.Generic;
using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Configuration.Interfaces.Base;
using Hylasoft.Logging.Factories;
using Hylasoft.Logging.Loggers.Interfaces;
using Hylasoft.Resolution;
using Hylasoft.Resolution.Extensions;

namespace Hylasoft.Logging
{
  public static class HLogging
  {
    public static IResultLoggingFactory Factory { private get; set; }

    static HLogging()
    {
      Factory = new ResultLoggingFactory();
    }

    public static ILoggingCollection Collection(IResultLoggingConfig configuration, IEnumerable<IResultLogger> loggers = null)
    {
      Result add;
      var collection = Factory.BuildCollection(configuration);
      if (loggers != null && !(add = collection.Add(loggers)))
        throw new Exception(add.GetMostRelevant());

      return collection;
    }

    public static ILoggingCollection Collection(IResultLoggingConfig configuration, params IResultLogger[] loggers)
    {
      return Collection(configuration, (IEnumerable<IResultLogger>) loggers);
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
