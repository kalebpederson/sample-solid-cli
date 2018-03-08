using DemoSolidCli.Domain;
using DemoSolidCli.Domain.Contracts;

namespace DemoSolidCli.CommandLineParser
{
  public class CommandAuthorizer : ICommandAuthorizer
  {
    public bool IsAuthorized(ICommandData commandData)
    {
      var credentialsData = commandData as CredentialsOptionsBase;
      if (credentialsData != null)
      {
        return credentialsData.UserName.ToLower().Contains("admin");
      }
      return false;
    }
  }
}