using System;
using System.IO;
using Autofac;
using Autofac.Configuration;
using Autofac.Core;
using DemoSolidCli.CommandLineParser;
using DemoSolidCli.Domain;
using DemoSolidCli.Domain.Contracts;
using Microsoft.Extensions.Configuration;

namespace DemoSolidCli.App
{
  public class AutofacAppBuilder
  {
    private readonly IContainer _container;

    public AutofacAppBuilder()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<CommitOptions>().As<ICommandData>();
      builder.RegisterType<CheckoutOptions>().As<ICommandData>();
      builder.RegisterType<DiffOptions>().As<ICommandData>();
      builder.RegisterType<CommitHandler>().As<ICommandDataHandler>();
      builder.RegisterType<CheckoutHandler>().As<ICommandDataHandler>();
      builder.RegisterType<DiffHandler>().As<ICommandDataHandler>();
      builder.RegisterType<CommandParser>().As<ICommandParser>();
      builder.RegisterType<CommandExecutor>().As<ICommandExecutor>();
      builder.RegisterType<CommandExecutor>();
      builder.RegisterType<CommandAuthorizer>().As<ICommandAuthorizer>();
      builder
        .RegisterType<AuthorizingCommandExecutor>()
        .As<ICommandExecutor>()
        .WithParameter(
          new ResolvedParameter(
            (pi, ctx) => pi.ParameterType == typeof (ICommandExecutor),
            (pi, ctx) => ctx.Resolve<CommandExecutor>())
        );
      builder.RegisterInstance((TextWriter) Console.Out);
      var configurationModule = CreateConfigurationModule();
      builder.RegisterModule(configurationModule);
      _container = builder.Build();
    }

    private static ConfigurationModule CreateConfigurationModule()
    {
      var config = new ConfigurationBuilder();
      const string jsonConfigFilePath = "config.json";
      if (File.Exists(jsonConfigFilePath))
      {
        config.AddJsonFile(jsonConfigFilePath);
      }
      return new ConfigurationModule(config.Build());
    }

    public ICommandParser CreateCommandParser()
    {
      return _container.Resolve<ICommandParser>();
    }

    public ICommandExecutor CreateCommandExecutor()
    {
      return _container.Resolve<ICommandExecutor>();
    }
  }
}