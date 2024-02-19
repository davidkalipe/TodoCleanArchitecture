using MediatR;
using Todo.Application.Interfaces;
using Todo.Application.MediatRManagement.Query;

namespace Todo.Application.MediatRManagement.Handlers;

public class GetTodoByIdHandler : IRequestHandler<GetTodoByIdQuery, Core.Domain.Models.Todo>
{
    private readonly ITodoService _todoService;

    public GetTodoByIdHandler(ITodoService todoService)
    {
        _todoService = todoService;
    }

    public async Task<Core.Domain.Models.Todo> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var lesTodos = await _todoService.GetTodoById(request.id);
        return lesTodos;
    }
}