using System.ComponentModel.DataAnnotations;

namespace Todo.Core.Domain.Models;

public class Todo
{
    [Key] public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageContentBase64 
    { 
        get 
        {
            return ImageContent != null ? Convert.ToBase64String(ImageContent) : null;
        } 
    }
    public byte[] ImageContent { get; set; }
    public bool IsDone { get; set; } = false;

    public Todo()
    {
        Id = Guid.NewGuid();
    }

}