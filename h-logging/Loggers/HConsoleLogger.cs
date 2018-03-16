using System;
using Hylasoft.Logging.Configuration;
using Hylasoft.Logging.Loggers.Base;
using Hylasoft.Resolution;
using OmniColour.Messages;
using OmniColour.Writers;

namespace Hylasoft.Logging.Loggers
{
  public class HConsoleLogger : HMessageLogger<IHConsoleLogConfiguration>
  {
    private readonly IColourWriter _writer;

    protected IColourWriter Writer
    {
      get { return _writer; }
    }

    public HConsoleLogger(IHConsoleLogConfiguration config, IColourWriter writer)
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
