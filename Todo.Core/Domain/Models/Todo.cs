using System.ComponentModel.DataAnnotations;

namespace Todo.Core.Domain.Models;

public class Todo
{
    [Key] public Guid Id { get; private set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsDone { get; set; } = false;

    public Todo()
    {
        Id = Guid.NewGuid();
    }

}