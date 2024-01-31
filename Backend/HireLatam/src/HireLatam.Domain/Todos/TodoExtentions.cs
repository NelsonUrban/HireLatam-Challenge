namespace HireLatam.Domain.Todos;

public static class TodoExtentions
{
    public static Todo FromRequestToTodo(this TodoRequest request)
    {
        return new Todo
        {
            Title = request.Title,
            Description = request.Description,
            IsCompleted = request.IsCompleted,
            DueDate = request.DueDate,
            CreationDate = request.CreationDate,
            UpdateDate = request.UpdateDate,
        };
    }
}
