using System;

namespace DemoSolidCli.Domain
{
  public class UnhandledCommandException : Exception
  {
    public Type CommandType { get; private set; }

    public UnhandledCommandException(Type commandType)
      : base(FormatMessage(commandType))
    {
      CommandType = commandType;
    }

    private static string FormatMessage(Type commandType)
    {
      return $"Command type {commandType} was not found.";
    }
  }
}