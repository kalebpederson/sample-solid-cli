using System.Collections.Generic;

namespace DemoSolidCli.Domain
{
  public class CommandExecutor : ICommandExecutor
  {
    private readonly IEnumerable<ICommandDataHandler> _commandDataHandlers;

    public CommandExecutor(IEnumerable<ICommandDataHandler> commandDataHandlers)
    {
      _commandDataHandlers = commandDataHandlers;
    }

    public void Execute(ICommandData commandData)
    {
      var executed = false;
      foreach (var handler in _commandDataHandlers)
      {
        if (handler.Handles(commandData))
        {
          handler.Handle(commandData);
          executed = true;
          break;
        }
      }
      if (!executed)
      {
        throw new UnhandledCommandException(commandData.GetType());
      }
    }
  }
}