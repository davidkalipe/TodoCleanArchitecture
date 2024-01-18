using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure;

public class TodoDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
{
    public TodoDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();
        optionsBuilder.UseNpgsql("Server=localhost;Database=todo_db;Username=postgres;Port=5432;Password=140809010;");

        return new TodoDbContext(optionsBuilder.Options);
    }
}