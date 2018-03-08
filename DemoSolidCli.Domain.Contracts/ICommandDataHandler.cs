namespace DemoSolidCli.Domain.Contracts
{
  public interface ICommandDataHandler
  {
    bool Handles(ICommandData commandData);
    void Handle(ICommandData commandData);
  }
}