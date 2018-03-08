using DemoSolidCli.Domain.Contracts;

namespace DemoSolidCli.Domain
{
  public abstract class TypedCommandDataHandler<T> : ICommandDataHandler where T: ICommandData
  {
    public bool Handles(ICommandData commandData)
    {
      return commandData.GetType() == typeof (T);
    }

    public void Handle(ICommandData commandData)
    {
      HandleInternal((T) commandData);
    }

    protected abstract void HandleInternal(T commandData);
  }
}