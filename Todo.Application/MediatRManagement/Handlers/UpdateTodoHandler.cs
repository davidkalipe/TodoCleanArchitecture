using MediatR;
using Todo.Application.Interfaces;
using Todo.Application.MediatRManagement.Commands;

namespace Todo.Application.MediatRManagement.Handlers;

public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand>
{
    private readonly ITodoService _todoService;

    public UpdateTodoHandler(ITodoService todoService)
    {
        _todoService = todoService;
    }

    public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        await _todoService.UpdateTodo(request.Todo);
        return default;
    }
}
