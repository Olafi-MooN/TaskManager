
using System.Collections.Concurrent;
using TaskManager.Communication.Entity;

namespace TaskManager.Infrastructure.DataStore;


public class DataStoreService<T> : IDataStore<T> where T : DataStoreDefaultProps
{
    private static readonly ConcurrentDictionary<string, List<T>> _dictionary = new ConcurrentDictionary<string, List<T>>();
    private readonly string _typeName;

    public DataStoreService()
    {
        _typeName = typeof(T).Name;
    }

    public void Create(T item)
    {
        if (!_dictionary.ContainsKey(_typeName))
        {
            _dictionary.TryAdd(_typeName, new List<T>());
        }

        if (_dictionary.TryGetValue(_typeName, out List<T>? items))
        {
            if (items.Any(x => x.Id == item.Id))
                throw new Exception($"An item with Id '{item.Id}' already exists.");

            items.Add(item);
        }
    }

    public void Delete(T item)
    {
        if (!_dictionary.TryGetValue(_typeName, out List<T>? items))
            throw new Exception($"The type '{_typeName}' does not exist.");

        items.Remove(item);
    }

    public T? Get(Guid id)
    {
        if (!_dictionary.TryGetValue(_typeName, out List<T>? items))
            throw new Exception($"The type '{_typeName}' does not exist.");

        return items.FirstOrDefault(item => item.Id == id);
    }

    public IEnumerable<T>? GetAll()
    {
        if (!_dictionary.TryGetValue(_typeName, out List<T>? items))
            throw new Exception($"The type '{_typeName}' does not exist.");

        return items;
    }

    public void Update(T item)
    {
        if (!_dictionary.TryGetValue(_typeName, out List<T>? items))
            throw new Exception($"The type '{_typeName}' does not exist.");

        var existingItem = items.FirstOrDefault(x => x.Id == item.Id);
        if (existingItem != null)
        {
            items.Remove(existingItem);
            items.Add(item);
        }
        else
        {
            throw new Exception($"Item with Id '{item.Id}' not found.");
        }
    }
}
