using Autofac;
using DemoSolidCli.Domain;
using DemoSolidCli.Domain.Contracts;

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
