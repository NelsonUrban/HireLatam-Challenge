using HireLatam.Domain.Todos;
using HireLatam.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HireLatam.Infrastructure.Repositories;

internal sealed class TodoRepository : ITodoRepository
{
    private readonly TodoContext _context;

    public TodoRepository(TodoContext context)
    {
        _context = context;
    }

    public async Task<Todo> AddAsync(Todo todo)
    {
        var result = await _context.Todos.AddAsync(todo);
        await SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Todo> DeleteAsync(Todo todo)
    {
        var entity = _context.Todos.Remove(todo).Entity;
        await SaveChangesAsync();
        return entity;
    }

    public async Task<bool> ExistAsync(Expression<Func<Todo, bool>> expression)
    {
        return await _context.Todos.AnyAsync(expression);
    }

    public async Task<List<Todo>> GetAllAsync()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<Todo> GetByAsync(Expression<Func<Todo, bool>> expression)
    {
        return await _context.Todos.FirstOrDefaultAsync(expression);
    }

    public async Task<Todo> UpdateAsync(Todo todo)
    {
        var entity = _context.Todos.Update(todo).Entity;
        await SaveChangesAsync();
        return entity;
    }

    private async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
