using Microsoft.EntityFrameworkCore;
using Todo.Application.Repository;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure.Repository;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _dbContext;

    public TodoRepository(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Core.Domain.Models.Todo>> GetAllTodo()
    {
        var lesTodo = await _dbContext.Todos.ToListAsync();
        return lesTodo;
    }

    public async Task<bool> AddTodo(Core.Domain.Models.Todo todo)
    {
        await _dbContext.Todos.AddAsync(todo);
        return true;
    }
}