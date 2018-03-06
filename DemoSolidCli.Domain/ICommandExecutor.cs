namespace DemoSolidCli.Domain
{
  public interface ICommandExecutor
  {
    void Execute(ICommandData commandData);
  }
}