using HireLatam.Domain.Shared;
using HireLatam.Domain.Todos;
using Microsoft.EntityFrameworkCore;

namespace HireLatam.Infrastructure.Contexts;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReferences).Assembly);
    }
}
