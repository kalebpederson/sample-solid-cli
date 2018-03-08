using System.IO;
using DemoSolidCli.Domain.Contracts;

namespace DemoSolidCli.Domain
{
  public class AuthorizingCommandExecutor : ICommandExecutor
  {
    private readonly ICommandExecutor _commandExecutor;
    private readonly TextWriter _textWriter;
    private readonly ICommandAuthorizer _commandAuthorizer;

    public AuthorizingCommandExecutor(
      ICommandExecutor commandExecutor,
      TextWriter textWriter,
      ICommandAuthorizer commandAuthorizer)
    {
      _commandExecutor = commandExecutor;
      _textWriter = textWriter;
      _commandAuthorizer = commandAuthorizer;
    }

    public void Execute(ICommandData commandData)
    {
      if (_commandAuthorizer.IsAuthorized(commandData))
      {
        _commandExecutor.Execute(commandData);
      }
      else
      {
        _textWriter.WriteLine(
          $"Unauthorized: command {commandData.GetType().FullName} requires admin permissions."
          );
      }
    }
  }
}