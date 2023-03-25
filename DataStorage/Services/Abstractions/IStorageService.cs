using ManagedCode.Communication;

namespace DataStorage.Services.Abstractions;

public interface IStorageService<T> : IDisposable
    where T : new()
{
    Result<int> SaveAsync(T model);

    Result<T> GetItemAsync(string id);

    Result<List<T>> GetAllItems(); 

    Result UpdateItemAsync(string id, T newValue);

    Result DeleteAsync(string id);
}