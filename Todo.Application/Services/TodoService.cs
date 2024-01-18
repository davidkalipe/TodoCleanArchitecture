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

    public List<Core.Domain.Models.Todo> GetAllTodo()
    {
        var lesTodo = _repo.GetAllTodo();
        return lesTodo;
    }

    public bool AddTodo(Core.Domain.Models.Todo todo)
    {
        _repo.AddTodo(todo);
        return true;
    }
}