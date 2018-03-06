namespace DemoSolidCli.Domain
{
  public interface ICommandAuthorizer
  {
    bool IsAuthorized(ICommandData commandData);
  }
}