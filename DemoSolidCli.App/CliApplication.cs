using DemoSolidCli.Domain;

namespace DemoSolidCli.App
{
  /// <summary>
  /// The main application uses the composition root to create
  /// the application's dependency graph. From there it can
  /// invoke the main component in the application.
  /// </summary>
  public class CliApplication : ICliApplication
  {
    public void Run(string[] args)
    {
      var builder = new AutofacAppBuilder();
      var parser = builder.CreateCommandParser();
      var executor = builder.CreateCommandExecutor();

      var result = parser.Parse(args);
      if (result != null)
      {
        executor.Execute(result);
      }
      // else the parser has displayed warning information about the usage
    }
  }
}