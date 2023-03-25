using System;
using DataStorage.Models;
using DataStorage.Services.Abstractions;
using ManagedCode.Communication;
using Microsoft.Extensions.Options;
using SQLite;

namespace DataStorage.Services;

public abstract class StorageService<T> : IStorageService<T>
        where T : new()
{
    private readonly DatabaseSettings _databaseSettings;
    private readonly SQLiteConnection _sqliteConnection;

    public StorageService(IOptions<DatabaseSettings> databaseOptions)
	{
        _databaseSettings = databaseOptions.Value;
        _sqliteConnection = new SQLiteConnection(_databaseSettings.FilePath);
	}

    public Result DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Result<T> GetItemAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Result<int> SaveAsync(T model)
    {
        var result = _sqliteConnection.Insert(model);

        return result < 0 ? Result.Succeed(result) : Result.Fail();
    }

    public Result UpdateItemAsync(string id, T newValue)
    {
        throw new NotImplementedException();
    }

    public CollectionResult<T> GetAllItems()
    {
        var items = _sqliteConnection.Table<T>().ToList();

        return CollectionResult<T>.Succeed(items);
    }

    public void Dispose()
    {
        _sqliteConnection.Close();
        _sqliteConnection.Dispose();
    }
}