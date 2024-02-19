using MediatR;

namespace Todo.Application.MediatRManagement.Query;

public record GetTodoByIdQuery(Guid id) : IRequest<Core.Domain.Models.Todo>;