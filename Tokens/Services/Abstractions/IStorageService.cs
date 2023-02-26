using ManagedCode.Communication;

namespace Tokens.Services.Abstractions;

public interface IStorageService<T>
{
    ValueTask<Result> SaveAsync(T model);

    ValueTask<Result<T>> GetItemAsync(string id);

    ValueTask<Result> UpdateItemAsync(string id, T newValue);

    ValueTask<Result> DeleteAsync(string id);
}