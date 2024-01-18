using Microsoft.EntityFrameworkCore;

namespace Todo.Infrastructure.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
        
    }

    public DbSet<Core.Domain.Models.Todo> Todos { get; set; }
}