using System.Collections.Generic;

namespace DemoSolidCli.Domain.Contracts
{
  public interface ICommandParser
  {
    ICommandData Parse(IEnumerable<string> args);
  }
}