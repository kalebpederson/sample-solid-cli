using CommandLine;
using DemoSolidCli.Domain;
using DemoSolidCli.Domain.Contracts;

namespace DemoSolidCli.CommandLineParser
{
  public abstract class CredentialsOptionsBase : ICommandData
  {
    [Option('u',"UserName", Required = true, HelpText = "Set the username")]
    public string UserName { get; set; }
    [Option('p',"Password", Required = true, HelpText = "Set the password")]
    public string Password { get; set; }
  }
}