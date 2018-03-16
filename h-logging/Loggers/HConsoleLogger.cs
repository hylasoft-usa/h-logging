using System;
using Hylasoft.Logging.Configuration;
using Hylasoft.Logging.Loggers.Base;
using Hylasoft.Logging.Loggers.Interfaces;
using Hylasoft.Resolution;
using OmniColour.Messages;
using OmniColour.Writers;

namespace Hylasoft.Logging.Loggers
{
  public class HConsoleLogger : HMessageLogger<IConsoleLogConfig>, IConsoleLogger
  {
    private readonly IColourWriter _writer;

    protected IColourWriter Writer
    {
      get { return _writer; }
    }

    public HConsoleLogger(IConsoleLogConfig config, IColourWriter writer)
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
