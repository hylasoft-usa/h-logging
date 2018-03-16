using System;
using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Loggers;
using Hylasoft.Logging.Loggers.Interfaces;
using OmniColour;
using OmniColour.Writers;

namespace Hylasoft.Logging.Factories
{
  internal class ResultLoggingFactory : IResultLoggingFactory, IResultLoggingIoc
  {
    internal ResultLoggingFactory()
    {
      ColourWriter = BuildColourWriterDefault;
      ConsoleLogger = BuildConsoleLoggerDefault;
      FileLogger = BuildFileLoggerDefault;
    }

    #region IResultLoggingFactory Implementation
    public IFileLogger BuildFileLogger(IFileLogConfig configuration)
    {
      return FileLogger(configuration);
    }

    public IConsoleLogger BuildConsoleLogger(IConsoleLogConfig configuration)
    {
      return ConsoleLogger(configuration);
    }
    #endregion

    #region IResoltLoggingIoc Implementation
    public Func<IColourWriter> ColourWriter { set; private get; }

    public Func<IConsoleLogConfig, IConsoleLogger> ConsoleLogger { set; private get; }

    public Func<IFileLogConfig, IFileLogger> FileLogger { set; private get; }
    #endregion

    #region Constructors
    protected IColourWriter BuildColourWriterDefault()
    {
      return Colour.Writer;
    }

    protected IConsoleLogger BuildConsoleLoggerDefault(IConsoleLogConfig configuration)
    {
      return new ConsoleLogger(configuration, ColourWriter());
    }

    protected IFileLogger BuildFileLoggerDefault(IFileLogConfig configuration)
    {
      return new FileLogger(configuration);
    }
    #endregion
  }
}
