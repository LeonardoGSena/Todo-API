using System.Runtime.CompilerServices;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTest;

[TestClass]
public class CreateTodoHandlerTests
{

    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("New Task", "Leonardo", DateTime.Now);
    private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
    private GenericCommandResult _result = new GenericCommandResult();

    [TestMethod]
    public void ShouldStopWhenInvalidCommand()
    {
        _result = (GenericCommandResult)_handler.Handle(_invalidCommand);

        Assert.AreEqual(_result.Success, false);
    }

    [TestMethod]
    public void ShouldCreateTodoWhenValidCommand()
    {
        _result = (GenericCommandResult)_handler.Handle(_validCommand);

        Assert.AreEqual(_result.Success, true);
    }
}
