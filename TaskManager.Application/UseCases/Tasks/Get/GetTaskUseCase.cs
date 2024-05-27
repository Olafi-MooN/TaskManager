using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;
using TaskManager.Infrastructure.DataStore;

namespace TaskManager.Application.UseCases.Tasks.Get;

public class GetTaskUseCase
{
    private readonly IDataStore<Communication.Entity.Task> _dataStore;

    public GetTaskUseCase(IDataStore<Communication.Entity.Task> dataStore)
    {
        _dataStore = dataStore;
    }

    public Communication.Entity.Task? Execute(Guid? id)
    {
        if (id is not null) return _dataStore.Get(id ?? Guid.NewGuid());
        return null;


    }
    public ResponseGetAllTaskJson Execute()
    {
        return new ResponseGetAllTaskJson { Tasks = _dataStore?.GetAll()?.ToList() };

    }
}
