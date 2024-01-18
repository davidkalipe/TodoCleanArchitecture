using Microsoft.AspNetCore.Mvc;
using Todo.Application.Interfaces;

namespace Todo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet(Name = "GetAllTodos")]
    public ActionResult GetAllTodos()
    {
        var lesTodos = _todoService.GetAllTodo();
        return Ok(lesTodos);
    }
}