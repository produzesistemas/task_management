using Application.Common.Interfaces.ApiServices;
using MediatR;

namespace Application.Tasks.Commands;
public class DeleteTaskCommand : IRequest<string>
{
    public Guid Id { get; set; }
}

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, string>
{
    private readonly ITaskApiService _TaskApiService;

    public DeleteTaskCommandHandler
    (
                ITaskApiService taskApiService
    )
    {
        _TaskApiService = taskApiService;
    }

    public async Task<string> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        await _TaskApiService.DeleteTask(request.Id);
        return await Task.FromResult("Tarefa excluida com sucesso");
    }


}
