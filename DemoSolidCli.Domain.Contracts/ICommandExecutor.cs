namespace DemoSolidCli.Domain.Contracts
{
  public interface ICommandExecutor
  {
    void Execute(ICommandData commandData);
  }
}