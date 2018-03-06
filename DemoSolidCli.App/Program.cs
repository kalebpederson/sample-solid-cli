using System;

namespace DemoSolidCli.App
{
  public class Program
  {
    static void Main(string[] args)
    {
      try
      {
        var app = new CliApplication();
        app.Run(args);
      }
      catch (Exception ex)
      {
        Console.Error.WriteLine($"Unexpected error: {ex.Message}");
      }
    }
  }
}
