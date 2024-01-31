namespace HireLatam.Domain.Todos;

public class TodoRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool? IsCompleted { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime? DueDate { get; set; }
}
