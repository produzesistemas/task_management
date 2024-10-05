
using FluentValidation;

namespace Application.Projects.Commands.CreateProject;
public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(createUserCommand => createUserCommand.Name)
        .NotEmpty()
        .MaximumLength(256).WithMessage("Campo Nome é obrigatório");
        RuleFor(createUserCommand => createUserCommand.UserId)
        .NotNull();
    }
}
