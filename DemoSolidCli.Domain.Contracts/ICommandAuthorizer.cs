namespace DemoSolidCli.Domain.Contracts
{
  public interface ICommandAuthorizer
  {
    bool IsAuthorized(ICommandData commandData);
  }
}