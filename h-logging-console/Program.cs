using Hylasoft.Logging.Configuration;
using Hylasoft.Logging.Loggers;
using Hylasoft.Resolution;
using OmniColour;
using OmniColour.Writers;

namespace Hylasoft.Logging.Console
{
  class Program
  {
    private static IHLogger _logger;
    private static IColourWriter _writer;
    private static IHConsoleLogConfiguration _config;

    private static IHLogger Logger { get { return _logger ?? (_logger = BuildLogger()); } }

    private static IColourWriter Writer { get { return _writer ?? (_writer = BuildWriter()); } }

    private static IHConsoleLogConfiguration Config { get { return _config ?? (_config = BuildConfig()); } }

    static void Main(string[] args)
    {
      var test = Result.SingleTrace("Test trace.");
      test += Result.SingleDebug("Test debug.");
      test += Result.SingleInfo("Test info.");
      test += Result.SingleWarning("Test warning.");
      test += Result.SingleError("Test error.");
      test += Result.SingleFatal("Test fatal.");

      Logger.LogSynchronous(test);

      var inline = Result.SingleInfo("Woah.");
      var inlineMessage = Writer.Message;

      inlineMessage.AppendFormat(OmniColours.BrightWhite, "{0,-15}", "This")
        .Append("is a ").Append(OmniColours.BrightCyan, "message").AppendLine(" for the masses.");

      inline += LoggingResult.SingleInfo(0, inlineMessage);
      inline += Result.SingleWarning("There it was.");

      Logger.LogSynchronous(inline);
    }

    private static IHLogger BuildLogger()
    {
      return new HConsoleLogger(Config, Writer);
    }

    private static IColourWriter BuildWriter()
    {
      return Colour.Writer;
    }

    private static IHConsoleLogConfiguration BuildConfig()
    {
      return new LoggingConfig
      {
        Level = HLoggingLevels.Verbose
      };
    }
  }
}
