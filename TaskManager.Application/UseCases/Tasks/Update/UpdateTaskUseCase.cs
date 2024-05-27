using TaskManager.Infrastructure.DataStore;

namespace TaskManager.Application.UseCases.Tasks.Update;

public class UpdateTaskUseCase
{
    private readonly IDataStore<Communication.Entity.Task> _dataStore;

    public UpdateTaskUseCase(IDataStore<Communication.Entity.Task> dataStore)
    {
        _dataStore = dataStore;
    }

    public void Execute(Communication.Entity.Task task)
    {
        _dataStore.Update(task);
    }
}
