namespace Todo.Application.Repository;

public interface ITodoRepository
{
    List<Core.Domain.Models.Todo> GetAllTodo();
    bool AddTodo(Core.Domain.Models.Todo todo);
}