using FluentValidation;

namespace Application.Projects.Queries;
public class GetProjectsQueryValidator : AbstractValidator<GetProjectsByUserQuery>
{
    public GetProjectsQueryValidator()
    {
        RuleFor(getBlobPreviewsQuery => getBlobPreviewsQuery.UserId)
            .NotEmpty().WithMessage("Id do usuário é obrigatório para a consulta!");
    }
}
