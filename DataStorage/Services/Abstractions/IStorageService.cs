using ManagedCode.Communication;

namespace DataStorage.Services.Abstractions;

public interface IStorageService<T> : IDisposable
    where T : new()
{
    Result<int> SaveAsync(T model);

    Result<T> GetItemAsync(string id);

    Result UpdateItemAsync(string id, T newValue);

    Result DeleteAsync(string id);

    CollectionResult<T> GetAllItems();

    Result<T> FirstOrDefault(Func<T, bool> query);

    CollectionResult<T> Where(Func<T, bool> query);

    CollectionResult<TOutput> Select<TOutput>(Func<T, TOutput> query);

    CollectionResult<T> OrderBy<TProperty>(Func<T, TProperty> query);
}