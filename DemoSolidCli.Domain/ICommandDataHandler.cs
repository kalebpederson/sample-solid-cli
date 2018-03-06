namespace DemoSolidCli.Domain
{
  public interface ICommandDataHandler
  {
    bool Handles(ICommandData commandData);
    void Handle(ICommandData commandData);
  }
}