using ManagedCode.Communication;

namespace Tokens.Services.Abstractions;

public interface IStorageService<T>
{
    ValueTask<Result<T>> SaveToken();          
}