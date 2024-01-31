using HireLatam.Domain.Shared;
using HireLatam.Domain.Todos;
using MediatR;

namespace HireLatam.Application.Features.Todos
{
    public class UpdateTodoCommand : IRequest<Result<Todo>>
    {
        public UpdateTodoCommand(int id, TodoRequest todo)
        {
            Id = id;
            Todo = todo;
        }
        public int Id { get; }
        public TodoRequest Todo { get; }
    }

    internal sealed class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, Result<Todo>>
    {
        private readonly ITodoRepository _repository;

        public UpdateTodoCommandHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Todo>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            if (request is null || request.Todo == null)
            {
                return Result<Todo>.Error("The request cannot be empty.");
            }

            var todo = await _repository.GetByAsync(t => t.Id == request.Id);
            if (todo == null)
            {
                return Result<Todo>.Error("The todo cannot be null.");
            }

            todo.Title = request.Todo.Title;
            todo.Description = request.Todo.Description;
            todo.CreationDate = request.Todo.CreationDate;
            todo.UpdateDate = request.Todo.UpdateDate;
            todo.DueDate = request.Todo.DueDate;
            todo.IsCompleted = request.Todo.IsCompleted;

            var result = await _repository.UpdateAsync(todo);

            return Result<Todo>.Success(result);
        }
    }
}
