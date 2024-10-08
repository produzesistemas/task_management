
using FluentValidation;

namespace Application.Tasks.Commands;
public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        RuleFor(d => d.Id).Must(x => x != Guid.Empty).WithMessage("Identificação da tarefa é obrigatória!");
    }
}
