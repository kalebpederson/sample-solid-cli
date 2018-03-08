using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DemoSolidCli.CommandLineParser;
using DemoSolidCli.Domain;
using DemoSolidCli.Domain.Contracts;
using NUnit.Framework;

namespace DemoSolidCli.Tests
{
    [TestFixture]
    public class CommandParserTests
    {
      [Test]
      public void Parse_writes_error_output_to_the_text_stream_when_no_arguments_provided()
      {
        var sb = new StringBuilder();
        var parser = CreateCliParser(sb);

        parser.Parse(EmptyArgs());

        Assert.That(sb.ToString(), Does.Contain("ERROR(S)"));
        Assert.That(sb.ToString(), Does.Contain("No verb selected."));
      }

      [Test]
      public void Parse_returns_instance_of_ICommandData_when_arguments_match_verb_requirements()
      {
        var parser = CreateCliParser();

        var commandData = parser.Parse(AsArgs("commit", "-u", "username", "-p", "password"));

        Assert.That(commandData, Is.Not.Null);
        Assert.That(commandData, Is.InstanceOf<ICommandData>());
        Assert.That(commandData, Is.InstanceOf<CommitOptions>());
      }

      [Test]
      public void Parse_returns_null_when_arguments_are_not_correct()
      {
        var parser = CreateCliParser();

        var commandData = parser.Parse(AsArgs("foobar", "-u", "username", "-p", "password"));

        Assert.That(commandData, Is.Null);
      }


      private static CommandParser CreateCliParser(
        StringBuilder sb = null, IEnumerable<Type> optionTypes = null)
      {
        var stream = new StringWriter(sb ?? new StringBuilder());
        return new CommandParser(stream, optionTypes ?? new [] {typeof(CommitOptions)});
      }

      private static IEnumerable<string> AsArgs(params string[] args)
      {
        return args;
      }

      private static IEnumerable<string> EmptyArgs()
      {
        return new string[] {};
      }
    }
}
