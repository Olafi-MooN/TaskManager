using TaskManager.Communication.Requests;
using TaskManager.Infrastructure.DataStore;


namespace TaskManager.Application.UseCases.Tasks.Create;

public class CreateTaskUseCase
{
    private readonly IDataStore<Communication.Entity.Task> _dataStore;

    public CreateTaskUseCase(IDataStore<Communication.Entity.Task> dataStore)
    {
        _dataStore = dataStore;
    }

    public void Execute(RequestTaskJson request)
    {

        _dataStore.Create(new Communication.Entity.Task
        {
            Description = request.Description,
            LimiteDateTime = request.LimiteDateTime,
            Id = Guid.NewGuid(),
            Name = request.Name,
            Priority = request.Priority,
            Status = request.Status,
        });
    }
}
