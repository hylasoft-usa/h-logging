using System;
using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Configuration.Interfaces.Base;
using Hylasoft.Logging.Loggers;
using Hylasoft.Logging.Loggers.Interfaces;
using OmniColour;
using OmniColour.Messages;
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
      LoggingCollection = BuildLoggingCollectionDefault;
      Message = BuildMessageDefault;
    }

    #region IResultLoggingFactory Implementation

    public IColourMessage BuildMessage()
    {
      return Message();
    }

    public IFileLogger BuildFileLogger(IFileLogConfig configuration)
    {
      return FileLogger(configuration);
    }

    public IConsoleLogger BuildConsoleLogger(IConsoleLogConfig configuration)
    {
      return ConsoleLogger(configuration);
    }

    public ILoggingCollection BuildCollection(IResultLoggingConfig configuration)
    {
      return LoggingCollection(configuration);
    }
    #endregion

    #region IResoltLoggingIoc Implementation
    public Func<IColourWriter> ColourWriter { set; private get; }

    public Func<IConsoleLogConfig, IConsoleLogger> ConsoleLogger { set; private get; }

    public Func<IFileLogConfig, IFileLogger> FileLogger { set; private get; }

    public Func<IResultLoggingConfig, ILoggingCollection> LoggingCollection { set; private get; }

    public Func<IColourMessage> Message { set; private get; }

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

    protected ILoggingCollection BuildLoggingCollectionDefault(IResultLoggingConfig configuration)
    {
      return new LoggingCollection(configuration);
    }

    protected IColourMessage BuildMessageDefault()
    {
      return Colour.Message;
    }
    #endregion
  }
}
