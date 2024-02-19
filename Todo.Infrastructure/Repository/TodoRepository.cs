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

    public async Task<Core.Domain.Models.Todo> GetTodoById(Guid id)
    {
        var todo = await _dbContext.Todos.Where(t => t.Id == id).FirstOrDefaultAsync();
        return todo;
    }

    public async Task<bool> AddTodo(Core.Domain.Models.Todo todo)
    {
        await _dbContext.Todos.AddAsync(todo);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Core.Domain.Models.Todo> UpdateTodo(Core.Domain.Models.Todo todo)
    {
        var existing = await _dbContext.Todos.Where(t => t.Id == todo.Id).FirstOrDefaultAsync();
        if (existing is null)
            return null!;
        
        existing.Title = todo.Title;
        existing.Description = todo.Description; 
        existing.IsDone = todo.IsDone;
        await _dbContext.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteTodo(Guid id)
    {
        var todo = await _dbContext.Todos.Where(t => t.Id == id).FirstOrDefaultAsync();
        if(todo is null)
            return false;
        _dbContext.Remove(todo);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}