using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOs;
using Todo.Application.MediatRManagement.Commands;
using Todo.Application.MediatRManagement.Query;

namespace Todo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public TodoController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetAllTodos")]
    public async Task<ActionResult> GetAllTodos()
    {
        var lesTodos = await _mediator.Send(new GetTodosQuery());
        var lesDtos = _mapper.Map<List<TodoDto>>(lesTodos);
        return Ok(lesDtos);
    }

    [HttpPost(Name = "AddTodo")]
    public async Task<ActionResult> AddTodo(TodoDto todoDto)
    {
        var todo = _mapper.Map<Core.Domain.Models.Todo>(todoDto);
        var request = await _mediator.Send(new AddTodoCommand(todo));
        return StatusCode(201, "todo bien ajouté");
    }

    [HttpPut(Name = "UpdateTodo")]
    public async Task<ActionResult<TodoDto>> UpdateTodo(Core.Domain.Models.Todo todo)
    {
        var request = await _mediator.Send(new UpdateTodoCommand(todo));
        var leDto = _mapper.Map<TodoDto>(request);
        return Ok(leDto);
    }
}