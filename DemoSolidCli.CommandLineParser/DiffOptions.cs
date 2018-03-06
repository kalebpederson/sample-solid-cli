using System.Collections.Generic;
using CommandLine;

namespace DemoSolidCli.CommandLineParser
{
  [Verb("diff", HelpText = "Diff changes in current checkout.")]
  public class DiffOptions : CredentialsOptionsBase
  {
    [Option('v', "Verbose", HelpText = "Use verbose output.")]
    public bool Verbose { get; set; }

    [Option('r', "Revision", HelpText = "Specify the revision.", Default = -1)]
    public int Revision { get; set; }

    [Option('f', "Files", HelpText = "Files to diff.", Separator = ',')]
    public IEnumerable<string> Files { get; set; }
  }
}