using MediatR;
using Todo.Application.Interfaces;
using Todo.Application.MediatRManagement.Commands;

namespace Todo.Application.MediatRManagement.Handlers;

public class AddTodoHandler : IRequestHandler<AddTodoCommand>
{
    private readonly ITodoService _todoService;

    public AddTodoHandler(ITodoService todoService)
    {
        _todoService = todoService;
    }

    public async Task<Unit> Handle(AddTodoCommand request, CancellationToken cancellationToken)
    {
        await _todoService.AddTodo(request.Todo);
        return default;
    }
}