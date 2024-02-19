using Todo.Application.Interfaces;
using Todo.Application.Repository;

namespace Todo.Application.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repo;

    public TodoService(ITodoRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Core.Domain.Models.Todo>> GetAllTodo()
    {
        var lesTodo = await  _repo.GetAllTodo();
        return lesTodo;
    }

    public async Task<Core.Domain.Models.Todo> GetTodoById(Guid id)
    {
        var todo = await _repo.GetTodoById(id);
        return todo;
    }

    public async Task<bool> AddTodo(Core.Domain.Models.Todo todo)
    {
        await _repo.AddTodo(todo);
        return true;
    }

    public async Task<Core.Domain.Models.Todo> UpdateTodo(Core.Domain.Models.Todo todo)
    {
        var existing = await _repo.UpdateTodo(todo);
        if (existing is null)
            return null;
        return existing;
    }

    public async Task<bool> DeleteTodo(Guid id)
    {
        await _repo.DeleteTodo(id);
        return true;
    }
}