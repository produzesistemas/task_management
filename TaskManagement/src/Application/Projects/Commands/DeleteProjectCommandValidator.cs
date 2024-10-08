
using FluentValidation;

namespace Application.Projects.Commands;
public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(d => d.Id).Must(x => x != Guid.Empty).WithMessage("Identificação do projeto é obrigatória!");

    }
}
