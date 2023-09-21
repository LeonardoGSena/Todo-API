using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests;

[TestClass]
public class TodoQueryTests
{
    private List<TodoItem> _items;

    public TodoQueryTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Tarefa 1", "usuario A", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 2", "usuario A", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 3", "leonardosena", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 4", "usuario A", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 5", "leonardosena", DateTime.Now));
    }

    [TestMethod("Should return task only from leonardosena user")]
    public void Test1()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("leonardosena"));
        Assert.AreEqual(2, result.Count());
    }
}
