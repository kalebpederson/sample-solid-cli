using CommandLine;

namespace DemoSolidCli.CommandLineParser
{
  [Verb("checkout", HelpText = "Checkout source code changes.")]
  public class CheckoutOptions : CredentialsOptionsBase
  {
    [Option('v', "Verbose", HelpText = "Use verbose output.")]
    public bool Verbose { get; set; }

    [Option('r', "Revision", HelpText = "Specify the revision.", Default = -1)]
    public int Revision { get; set; }

    [Option('b', "Branch", HelpText = "Branch to checkout.", Default = "master")]
    public string Branch { get; set; }
  }
}