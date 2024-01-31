using HireLatam.Domain.Todos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HireLatam.Infrastructure.Configurations;

internal class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
               .IsRequired();

        builder.Property(t => t.Description);

        builder.Property(t => t.IsCompleted);

        builder.Property(t => t.CreationDate);

        builder.Property(t => t.UpdateDate);

        builder.Property(t => t.DueDate);
    }
}
