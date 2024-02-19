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
        string base64image = "";
        return Ok(lesDtos);
    }

    [HttpGet("GetTodoById{id}")]
    public async Task<ActionResult> GetTodoById(Guid id)
    {
        var todo = await _mediator.Send(new GetTodoByIdQuery(id));
        var dto = _mapper.Map<TodoDto>(todo);
        string base64Image = dto.ImageContentBase64;
        byte[] Picture = Convert.FromBase64String(base64Image);
        return File(Picture, "image/png");

    }

    [HttpPost(Name = "AddTodo")]
    public async Task<ActionResult> AddTodo([FromForm]TodoCreateDto todoCreateDto )
    {
        var file = todoCreateDto.File;
        using (var ms = new MemoryStream())
        {
            file.CopyTo(ms);
            var todo = _mapper.Map<Core.Domain.Models.Todo>(todoCreateDto);
            todo.ImageContent = ms.ToArray();
            await _mediator.Send(new AddTodoCommand(todo));
        }
        
        return StatusCode(201, "todo bien ajouté");
    }

    [HttpPut(Name = "UpdateTodo")]
    public async Task<ActionResult> UpdateTodo(Core.Domain.Models.Todo todo)
    {
        var request = await _mediator.Send(new UpdateTodoCommand(todo));
        return Ok(request);
    }
}