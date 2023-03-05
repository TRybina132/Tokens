using System;
using DataStorage.Models;
using DataStorage.Services.Abstractions;
using ManagedCode.Communication;
using Microsoft.Extensions.Options;
using SQLite;

namespace DataStorage.Services;

public abstract class StorageService<T> : IStorageService<T>
{
    private readonly DatabaseSettings _databaseSettings;
    private readonly SQLiteConnection _sqliteConnection;

    public StorageService(IOptions<DatabaseSettings> databaseOptions)
	{
        _databaseSettings = databaseOptions.Value;
        _sqliteConnection = new SQLiteConnection(_databaseSettings.FilePath);
	}

    public ValueTask<Result> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result<T>> GetItemAsync(string id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result> SaveAsync(T model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Result> UpdateItemAsync(string id, T newValue)
    {
        throw new NotImplementedException();
    }
}