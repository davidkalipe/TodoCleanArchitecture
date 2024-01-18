using MediatR;

namespace Todo.Application.MediatRManagement.Query;

public record GetTodosQuery() : IRequest<List<Core.Domain.Models.Todo>>;
