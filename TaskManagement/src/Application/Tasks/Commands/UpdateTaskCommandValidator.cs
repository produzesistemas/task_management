
using FluentValidation;

namespace Application.Tasks.Commands;
public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(createCommand => createCommand.Title).NotEmpty().WithMessage("Campo Título é obrigatório");
        RuleFor(createCommand => createCommand.Title).MaximumLength(256).WithMessage("Campo Título não pode ultrapassar 256 caracteres");
        RuleFor(createCommand => createCommand.Status).NotEmpty().WithMessage("Campo Status é obrigatório");
        RuleFor(createCommand => createCommand.Status).MaximumLength(20).WithMessage("Campo Status não pode ultrapassar 20 caracteres");
        RuleFor(createCommand => createCommand.DueDate).NotNull().WithMessage("Data de vencimento da tarefa é obrigatória");
        RuleFor(createCommand => createCommand.UserId).NotEmpty().WithMessage("Identificação do usuário é obrigatória");
        RuleFor(createCommand => createCommand.ProjectId).NotEmpty().WithMessage("Identificação do projeto é obrigatória");
        RuleFor(createCommand => createCommand.Id).NotEmpty().WithMessage("Identificação da tarefa é obrigatória");

    }
}
