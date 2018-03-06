using CommandLine;

namespace DemoSolidCli.CommandLineParser
{
  [Verb("commit", HelpText = "Commit source code changes.")]
  public class CommitOptions : CredentialsOptionsBase
  {
    [Option('v', "Verbose", HelpText = "Use verbose output.")]
    public bool Verbose { get; set; }
  }
}