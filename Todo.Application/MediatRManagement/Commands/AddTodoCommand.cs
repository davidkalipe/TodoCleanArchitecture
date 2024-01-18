using MediatR;

namespace Todo.Application.MediatRManagement.Commands;

public record AddTodoCommand(Core.Domain.Models.Todo Todo) : IRequest;