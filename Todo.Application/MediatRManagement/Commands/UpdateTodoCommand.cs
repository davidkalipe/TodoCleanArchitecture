using MediatR;

namespace Todo.Application.MediatRManagement.Commands;

public record UpdateTodoCommand(Core.Domain.Models.Todo Todo) : IRequest;