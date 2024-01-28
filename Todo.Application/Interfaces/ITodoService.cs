namespace Todo.Application.Interfaces;

public interface ITodoService
{
    Task<List<Core.Domain.Models.Todo>> GetAllTodo();
    Task<bool> AddTodo(Core.Domain.Models.Todo todo);
    Task<Core.Domain.Models.Todo> UpdateTodo(Core.Domain.Models.Todo todo);
    Task<bool> DeleteTodo(Guid id);
}