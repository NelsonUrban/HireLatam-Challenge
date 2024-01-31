using FluentValidation;
using HireLatam.Domain.Todos;

namespace HireLatam.Application.Validators.Todos;

internal sealed class TodoRequestValidator : AbstractValidator<TodoRequest>
{
    public TodoRequestValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage("The field title is required.");

        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage("The field description is required.");
    }
}
