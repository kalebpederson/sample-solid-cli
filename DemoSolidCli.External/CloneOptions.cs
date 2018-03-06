using CommandLine;
using DemoSolidCli.CommandLineParser;

namespace DemoSolidCli.External
{
  [Verb("clone", HelpText = "Clone to the current directory.")]
  public class CloneOptions : CredentialsOptionsBase
  {
    [Option('b', "Branch", Default = "master")]
    public string Branch { get; set; }
  }
}