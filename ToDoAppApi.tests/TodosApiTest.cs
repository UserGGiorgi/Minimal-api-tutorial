using System.Threading.Tasks;
public class TodosApiTests
{
    private ToDoDb CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<TodoDb>()
            .UseInMemoryDatabase("TestTodoList")
            .Options;

        var dbContext = new TodoDb(options);

        dbContext.Todos.AddRange(
            new Todo { Id = 1, Name = "Test Todo 1", IsComplete = true },
            new Todo { Id = 2, Name = "Test Todo 2", IsComplete = false }
        );
        dbContext.SaveChanges();

        return dbContext;
    }

    [Fact]
    public async Task GetAllTodos_ReturnsOkOfTodosResult()
    {
        var db = CreateDbContext();

        var result = await GetAllTodos(db);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var todos = Assert.IsAssignableFrom<Todo[]>(okResult.Value);

        Assert.Equal(2, todos.Length);
        Assert.Contains(todos, t => t.Name == "Test Todo 1");
        Assert.Contains(todos, t => t.Name == "Test Todo 2");
    }

    private async Task<IResult> GetAllTodos(TodoDb db)
    {
        return TypedResults.Ok(await db.Todos.ToArrayAsync());
    }
}
