namespace Todo.Application.DTOs;

public class TodoDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
    public string ImageContentBase64 
    { 
        get 
        {
            return ImageContent != null ? Convert.ToBase64String(ImageContent) : null;
        } 
    }
    public byte[] ImageContent { get; set; }
    
}