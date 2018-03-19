using Hylasoft.Resolution;
using OmniColour.Messages;

namespace Hylasoft.Logging.Resolution
{
  /// <summary>
  /// A specialized result issue that can store an IColourMessage.
  /// </summary>
  internal class LoggingIssue : ResultIssue
  {
    private readonly IColourMessage _colourMessage;

    public const long NonIssueCode = 0;

    public IColourMessage ColourMessage { get { return _colourMessage; } }

    protected internal LoggingIssue(IColourMessage message, ResultIssueLevels level, long issueCode = 0)
      : base(BuildMessage(message), level, issueCode)
    {
      _colourMessage = message;
    }

    protected static string BuildMessage(IColourMessage message)
    {
      return message == null
        ? string.Empty
        : message.BuildRaw();
    }
  }
}
