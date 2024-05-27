using TaskManager.Infrastructure.DataStore;

namespace TaskManager.Application.UseCases.Tasks.NewFolder;

public class DeleteTaskUseCase
{
    private readonly IDataStore<Communication.Entity.Task> _dataStore;

    public DeleteTaskUseCase(IDataStore<Communication.Entity.Task> dataStore)
    {
        _dataStore = dataStore;
    }


    public void Execute(Guid id)
    {
        var task = _dataStore.Get(id);

        if (task is not null)
            _dataStore.Delete(task);
    }

}
