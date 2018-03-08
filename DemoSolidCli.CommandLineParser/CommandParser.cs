using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommandLine;
using DemoSolidCli.Domain;
using DemoSolidCli.Domain.Contracts;

namespace DemoSolidCli.CommandLineParser
{
  public class CommandParser : ICommandParser
  {
    private readonly TextWriter _outWriter;
    private readonly IEnumerable<Type> _optionTypes;

    // this constructor was made internal so that it won't be picked up
    // by the IoC container and so that we can still use it for testing
    internal CommandParser(TextWriter outWriter, IEnumerable<Type> optionTypes)
    {
      _outWriter = outWriter;
      _optionTypes = optionTypes;
    }

    // this constructor will be used by the IoC container as we didn't register
    // a set of "Type" instances with the container...
    public CommandParser(TextWriter outWriter, IEnumerable<ICommandData> optionTypes)
    {
      _outWriter = outWriter;
      _optionTypes = optionTypes.Select(x => x.GetType());
    }

    public ICommandData Parse(IEnumerable<string> args)
    {
      var parser = new Parser(settings =>
      {
        settings.CaseSensitive = false;
        settings.EnableDashDash = true;
        settings.IgnoreUnknownArguments = false;
        settings.HelpWriter = _outWriter;
      });
      var parsed = parser.ParseArguments(args, _optionTypes.ToArray());
      if (parsed.Tag == ParserResultType.Parsed)
      {
        var parsedResult = (Parsed<object>) parsed;
        return (ICommandData) parsedResult.Value;
      }
      return null;
    }

  }

}