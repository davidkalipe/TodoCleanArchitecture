using MediatR;
using Todo.Application.MediatRManagement.Query;
using Todo.Application.Interfaces;

namespace Todo.Application.MediatRManagement.Handlers;

public class GetTodosHandler : IRequestHandler<GetTodosQuery, List<Core.Domain.Models.Todo>>
{
    private readonly ITodoService _todoService;

    public GetTodosHandler(ITodoService todoService)
    {
        _todoService = todoService;
    }

    public async Task<List<Core.Domain.Models.Todo>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
         var lesTodos = await _todoService.GetAllTodo();
         return lesTodos;
    }
}
