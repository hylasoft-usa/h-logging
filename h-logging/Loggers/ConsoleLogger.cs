using System;
using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Loggers.Base;
using Hylasoft.Logging.Loggers.Interfaces;
using Hylasoft.Resolution;
using OmniColour.Messages;
using OmniColour.Writers;

namespace Hylasoft.Logging.Loggers
{
  public class ConsoleLogger : ResultMessageLogger<IConsoleLogConfig>, IConsoleLogger
  {
    private readonly IColourWriter _writer;

    protected IColourWriter Writer
    {
      get { return _writer; }
    }

    protected internal ConsoleLogger(IConsoleLogConfig config, IColourWriter writer)
      : base(config)
    {
      _writer = writer;
    }

    protected override Result LogMessage(IColourMessage message)
    {
      try
      {
        Writer.Write(message);
        return Result.Success;
      }
      catch (Exception e)
      {
        return Result.Error(e);
      }
    }
  }
}
