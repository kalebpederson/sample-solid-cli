using System.IO;
using DemoSolidCli.Domain;

namespace DemoSolidCli.External
{
  public class CloneHandler : TypedCommandDataHandler<CloneOptions>
  {
    private readonly TextWriter _textWriter;

    public CloneHandler(TextWriter textWriter)
    {
      _textWriter = textWriter;
    }

    protected override void HandleInternal(CloneOptions commandData)
    {
      _textWriter.WriteLine(
        $"Cloning branch {commandData.Branch} for user {commandData.UserName}"
        );
    }
  }
}