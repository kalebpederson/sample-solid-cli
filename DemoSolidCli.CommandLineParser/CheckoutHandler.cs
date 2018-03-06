using System.IO;
using DemoSolidCli.Domain;

namespace DemoSolidCli.CommandLineParser
{
  public class CheckoutHandler : TypedCommandDataHandler<CheckoutOptions>
  {
    private readonly TextWriter _textWriter;

    public CheckoutHandler(TextWriter textWriter)
    {
      _textWriter = textWriter;
    }

    protected override void HandleInternal(CheckoutOptions commandData)
    {
      var revision = (commandData.Revision != -1) ? commandData.Revision.ToString() : "'last'";
      _textWriter.WriteLine($"Checking out revision {revision} for user '{commandData.UserName}'");
    }
  }
}