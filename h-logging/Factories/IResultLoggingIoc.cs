using System;
using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Loggers.Interfaces;
using OmniColour.Writers;

namespace Hylasoft.Logging.Factories
{
  public interface IResultLoggingIoc
  {
    Func<IColourWriter> ColourWriter { set; }

    Func<IConsoleLogConfig, IConsoleLogger> ConsoleLogger { set; }

    Func<IFileLogConfig, IFileLogger> FileLogger { set; } 
  }
}
