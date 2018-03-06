using Autofac;
using DemoSolidCli.Domain;

namespace DemoSolidCli.External
{
    public class Registrations: Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.RegisterType<CloneOptions>().As<ICommandData>();
        builder.RegisterType<CloneHandler>().As<ICommandDataHandler>();
      }
    }
}
