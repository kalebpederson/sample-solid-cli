using System.IO;
using DemoSolidCli.Domain;

namespace DemoSolidCli.CommandLineParser
{
  public class CommitHandler : TypedCommandDataHandler<CommitOptions>
  {
    private readonly TextWriter _textWriter;

    public CommitHandler(TextWriter textWriter)
    {
      _textWriter = textWriter;
    }

    protected override void HandleInternal(CommitOptions commandData)
    {
      _textWriter.WriteLine($"Committing for user '{commandData.UserName}'");
    }
  }
}