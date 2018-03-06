using System.IO;
using System.Linq;
using DemoSolidCli.Domain;

namespace DemoSolidCli.CommandLineParser
{
  public class DiffHandler : TypedCommandDataHandler<DiffOptions>
  {
    private readonly TextWriter _textWriter;

    public DiffHandler(TextWriter textWriter)
    {
      _textWriter = textWriter;
    }

    protected override void HandleInternal(DiffOptions commandData)
    {
      var revision = (commandData.Revision != -1) ? commandData.Revision.ToString() : "'last'";
      var files = (!commandData.Files.Any() ? "all" : string.Join(", ", commandData.Files.Select(x => "'" + x + "'")));
      _textWriter.WriteLine(
        $"Diff'ing revision {revision} for user '{commandData.UserName}' with " +
        $"verbose={commandData.Verbose} on files: {files}"
        );
    }
  }
}