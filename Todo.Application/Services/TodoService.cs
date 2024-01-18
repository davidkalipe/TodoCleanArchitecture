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

    public async Task<bool> AddTodo(Core.Domain.Models.Todo todo)
    {
        await _repo.AddTodo(todo);
        return true;
    }
}