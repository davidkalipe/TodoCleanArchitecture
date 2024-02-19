using Microsoft.AspNetCore.Http;

namespace Todo.Application.DTOs;

public class TodoCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
    public IFormFile File { get; set; }
}