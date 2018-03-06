using System.Collections.Generic;

namespace DemoSolidCli.Domain
{
  public interface ICommandParser
  {
    ICommandData Parse(IEnumerable<string> args);
  }
}