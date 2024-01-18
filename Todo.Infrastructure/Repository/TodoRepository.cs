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

    public List<Core.Domain.Models.Todo> GetAllTodo()
    {
        var lesTodo = _dbContext.Todos.ToList();
        return lesTodo;
    }

    public bool AddTodo(Core.Domain.Models.Todo todo)
    {
        _dbContext.Todos.Add(todo);
        return true;
    }
}