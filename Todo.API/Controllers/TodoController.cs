using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.MediatRManagement.Query;

namespace Todo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllTodos")]
    public async Task<ActionResult> GetAllTodos()
    {
        var lesTodos = await _mediator.Send(new GetTodosQuery());
        return Ok(lesTodos);
    }
}