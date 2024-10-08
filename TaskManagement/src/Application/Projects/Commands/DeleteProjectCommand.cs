
using Application.Common.Interfaces.ApiServices;
using Application.Projects.Commands;
using Application.Tasks.Commands;
using MediatR;

namespace Application.Projects.Commands;
public class DeleteProjectCommand : IRequest<string>
{
    public Guid Id { get; set; }
}

public Guid Id { get; set; }
}

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, string>
{
    private readonly IProjectApiService _ProjectApiService;

    public DeleteProjectCommandHandler
    (
                IProjectApiService projectApiService
    )
    {
        _ProjectApiService = projectApiService;
    }

    public async Task<string> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        await _ProjectApiService.DeleteProject(request.Id);
        return await Task.FromResult("Projeto excluida com sucesso");
    }


}

