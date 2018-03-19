using Hylasoft.Logging.Configuration;
using Hylasoft.Logging.Configuration.Types;
using Hylasoft.Logging.Loggers.Interfaces;
using Hylasoft.Logging.Resolution;
using Hylasoft.Resolution;
using OmniColour;
using OmniColour.Writers;

namespace Hylasoft.Logging.Console
{
  class Program
  {
    private static ILoggingCollection _logger;
    private static IResultLogger _fileLogger;
    private static IResultLogger _consoleLogger;
    private static IColourWriter _writer;

    private static ILoggingCollection Logger { get { return _logger ?? (_logger = BuildLogger()); } }

    private static IResultLogger FileLogger { get { return _fileLogger ?? (_fileLogger = BuildFileLogger()); } }

    private static IResultLogger ConsoleLogger { get { return _consoleLogger ?? (_consoleLogger = BuildConsoleLogger()); } }

    private static IColourWriter Writer { get { return _writer ?? (_writer = BuildWriter()); } }

    static void Main()
    {
      var test = Result.SingleTrace("Test trace.");
      test += Result.SingleDebug("Test debug.");
      test += Result.SingleInfo("Test info.");
      test += Result.SingleWarning("Test warning.");
      test += Result.SingleError("Test error.");
      test += Result.SingleFatal("Test fatal.");

      Logger.LogSynchronous(test);
      Logger.Remove("ConsoleLogger");

      var inline = Result.SingleInfo("Woah.");
      var inlineMessage = Writer.Message;

      inlineMessage.AppendFormat(OmniColours.BrightWhite, "{0,-15}", "This")
        .Append("is a ").Append(OmniColours.BrightCyan, "message").Append(" for the masses.");

      inline += LoggingResult.SingleInfo(inlineMessage);
      inline += Result.SingleWarning("There it was.");
      inline += Result.SingleInfo("And there it went.");

      inline += LoggingResult.SingleInfo("And a single logging message.");

      Logger.LogSynchronous(inline);
    }

    private static ILoggingCollection BuildLogger()
    {
      var config = new LoggingCollectionConfig();
      return HLogging.Collection(config, ConsoleLogger, FileLogger);
    }

    private static IResultLogger BuildConsoleLogger()
    {
      var config = new ConsoleLogConfig("ConsoleLogger")
      {
        Level = LoggingLevels.Verbose
      };

      return HLogging.ConsoleLogger(config);
    }

    private static IResultLogger BuildFileLogger()
    {
      var config = new FileLogConfig("FileLogger")
      {
        LogLocation = @"..\..\..",
        Level = LoggingLevels.Quiet 
      };

      return HLogging.FileLogger(config);
    }

    private static IColourWriter BuildWriter()
    {
      return Colour.Writer;
    }
  }
}
