
using FluentValidation;

namespace Application.Projects.Commands.CreateProject;
public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Campo Nome é obrigatório");
        RuleFor(c => c.UserId).NotEmpty()
        .WithMessage("Identificação do usuário é obrigatória");
    }
}
