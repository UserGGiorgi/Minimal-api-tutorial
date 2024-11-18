using Microsoft.EntityFrameworkCore;

namespace ToDoAppApi;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options)
        : base(options) { }

    public DbSet<Todo> Todos => this.Set<Todo>();
}
