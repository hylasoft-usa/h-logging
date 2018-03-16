using Hylasoft.Logging.Configuration.Interfaces;
using Hylasoft.Logging.Configuration.Types;
using Hylasoft.Logging.Resolution;
using Hylasoft.Resolution;
using OmniColour;
using OmniColour.Writers;

namespace Hylasoft.Logging.Console
{
  class Program
  {
    private static IResultLogger _logger;
    private static IResultLogger _fileLogger;
    private static IColourWriter _writer;
    private static IConsoleLogConfig _config;

    private static IResultLogger Logger { get { return _logger ?? (_logger = BuildLogger()); } }

    private static IResultLogger FileLogger { get { return _fileLogger ?? (_fileLogger = BuildFileLogger()); } }

    private static IColourWriter Writer { get { return _writer ?? (_writer = BuildWriter()); } }

    private static IConsoleLogConfig Config { get { return _config ?? (_config = BuildConfig()); } }

    static void Main()
    {
      var test = Result.SingleTrace("Test trace.");
      test += Result.SingleDebug("Test debug.");
      test += Result.SingleInfo("Test info.");
      test += Result.SingleWarning("Test warning.");
      test += Result.SingleError("Test error.");
      test += Result.SingleFatal("Test fatal.");

      Logger.LogSynchronous(test);
      FileLogger.LogSynchronous(test);

      var inline = Result.SingleInfo("Woah.");
      var inlineMessage = Writer.Message;

      inlineMessage.AppendFormat(OmniColours.BrightWhite, "{0,-15}", "This")
        .Append("is a ").Append(OmniColours.BrightCyan, "message").AppendLine(" for the masses.");

      inline += LoggingResult.SingleInfo(0, inlineMessage);
      inline += Result.SingleWarning("There it was.");
      inline += Result.SingleTrace("And there it went.");

      Logger.LogSynchronous(inline);
      FileLogger.LogSynchronous(inline);
    }

    private static IResultLogger BuildLogger()
    {
      return HLogging.ConsoleLogger(Config);
    }

    private static IResultLogger BuildFileLogger()
    {
      var config = new FileConfig
      {
        LogName = "Console.log",
        LogLocation = @"..\..\.."
      };

      return HLogging.FileLogger(config);
    }

    private static IColourWriter BuildWriter()
    {
      return Colour.Writer;
    }

    private static IConsoleLogConfig BuildConfig()
    {
      return new LoggingConfig
      {
        Level = LoggingLevels.Verbose
      };
    }
  }
}
