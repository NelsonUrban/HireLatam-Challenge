using System.Linq.Expressions;

namespace HireLatam.Domain.Todos;

public interface ITodoRepository
{
    Task<List<Todo>> GetAllAsync();
    Task<Todo> GetByAsync(Expression<Func<Todo, bool>> id);
    Task<Todo> AddAsync(Todo todo);
    Task<Todo> UpdateAsync(Todo todo);
    Task<Todo> DeleteAsync(Todo todo);
    Task<bool> ExistAsync(Expression<Func<Todo, bool>> expression);
}
