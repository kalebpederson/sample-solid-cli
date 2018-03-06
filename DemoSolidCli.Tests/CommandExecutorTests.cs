using System;
using AutoFixture;
using DemoSolidCli.CommandLineParser;
using DemoSolidCli.Domain;
using Moq;
using NUnit.Framework;

namespace DemoSolidCli.Tests
{
  [TestFixture]
  public class CommandExecutorTests
  {
    private readonly Fixture _fixture = new Fixture();

    [Test]
    public void CommandExecutor_calls_Handles_method_with_provided_command_data()
    {
      var commandData = CreateCommandData();
      var mockCommandDataHandler = CreateMockCommandDataHandlerThatDoesNotHandle(commandData);
      var executor = CreateCommandExecutor(mockCommandDataHandler.Object);

      IgnoreFailureOf(() => executor.Execute(commandData));

      mockCommandDataHandler.Verify(x => x.Handles(commandData), Times.Once);
    }

    [Test]
    public void CommandExecutor_does_not_call_Handle_when_Handles_returns_false()
    {
      var commandData = CreateCommandData();
      var mockCommandDataHandler = CreateMockCommandDataHandlerThatDoesNotHandle(commandData);
      var executor = CreateCommandExecutor(mockCommandDataHandler.Object);

      IgnoreFailureOf(() => executor.Execute(commandData));

      mockCommandDataHandler.Verify(x => x.Handle(commandData), Times.Never);
    }

    [Test]
    public void CommandExecutor_calls_Handle_method_with_provided_options_when_Handles_returns_true()
    {
      var commandData = CreateCommandData();
      var mockCommandDataHandler = CreateMockCommandDataHandlerThatHandles(commandData);
      var executor = CreateCommandExecutor(mockCommandDataHandler.Object);

      executor.Execute(commandData);

      mockCommandDataHandler.Verify(x => x.Handles(commandData), Times.Once);
    }

    private static CommandExecutor CreateCommandExecutor(ICommandDataHandler commandDataHandler)
    {
      return new CommandExecutor(new [] {commandDataHandler});
    }

    private CommitOptions CreateCommandData(string expectedUserName = null)
    {
      return new CommitOptions
      {
        UserName = expectedUserName ?? _fixture.Create<string>()
      };
    }

    private static Mock<ICommandDataHandler> CreateMockCommandDataHandlerThatDoesNotHandle(CommitOptions commandData)
    {
      var mockCommandDataHandler = new Mock<ICommandDataHandler>();
      mockCommandDataHandler.Setup(x => x.Handles(commandData)).Returns(false);
      return mockCommandDataHandler;
    }

    private static Mock<ICommandDataHandler> CreateMockCommandDataHandlerThatHandles(CommitOptions commandData)
    {
      var mockCommandDataHandler = new Mock<ICommandDataHandler>();
      mockCommandDataHandler.Setup(x => x.Handles(commandData)).Returns(true);
      return mockCommandDataHandler;
    }

    private void IgnoreFailureOf(Action action)
    {
      try
      {
        action.Invoke();
      }
      catch (Exception)
      {
      }
    }
  }
}