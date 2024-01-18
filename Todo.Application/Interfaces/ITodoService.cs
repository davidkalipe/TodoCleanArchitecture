namespace Todo.Application.Interfaces;

public interface ITodoService
{
    List<Core.Domain.Models.Todo> GetAllTodo();
    bool AddTodo(Core.Domain.Models.Todo todo);
}