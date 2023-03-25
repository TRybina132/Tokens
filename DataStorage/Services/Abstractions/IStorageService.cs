using ManagedCode.Communication;

namespace DataStorage.Services.Abstractions;

public interface IStorageService<T> : IDisposable
    where T : new()
{
    Result Save(T model);

    Result<T> GetItem(string id);

    Result UpdateItem(T newValue);

    Result Delete(string id);

    CollectionResult<T> GetAllItems();

    Result<T> FirstOrDefault(Func<T, bool> query);

    CollectionResult<T> Where(Func<T, bool> query);

    CollectionResult<TOutput> Select<TOutput>(Func<T, TOutput> query);

    CollectionResult<T> OrderBy<TProperty>(Func<T, TProperty> query);
}