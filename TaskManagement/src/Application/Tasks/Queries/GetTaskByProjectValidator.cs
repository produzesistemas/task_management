
using FluentValidation;

namespace Application.Tasks.Queries;
public class GetTaskByProjectValidator : AbstractValidator<GetTasksByProjectQuery>
{
    public GetTaskByProjectValidator()
    {
        RuleFor(g => g.ProjectId).NotEmpty().WithMessage("Identificação do projeto é obrigatória!");
    }
}
