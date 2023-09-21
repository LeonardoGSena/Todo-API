using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests;

[TestClass]
public class TodoItemTests
{
    private readonly TodoItem _todoItem = new TodoItem("New Task", "Leonardo", DateTime.Now);

    [TestMethod]
    public void ShouldCreateTodoItemUndone()
    {
        Assert.AreEqual(_todoItem.Done, false);
    }

    [TestMethod]
    public void ShouldMarkAsDone()
    {
        _todoItem.MakeAsDone();

        Assert.AreEqual(_todoItem.Done, true);
    }


    [TestMethod]
    public void ShouldMarkAsUndone()
    {
        _todoItem.MakeAsUndone();

        Assert.AreEqual(_todoItem.Done, false);
    }

    [TestMethod]
    public void ShouldUpdateTitle()
    {
        _todoItem.UpdateTitle("New Task 1");
        var target = "New Task 1";

        Assert.AreEqual(_todoItem.Title, target);
    }
}
