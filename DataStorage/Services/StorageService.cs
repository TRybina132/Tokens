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

    public CollectionResult<T> Where(Func<T, bool> query)
    {
        var result = _sqliteConnection.Table<T>()
            .Where(query)
            .ToList();

        return CollectionResult<T>.Succeed(result);
    }

    public Result<T> FirstOrDefault(Func<T, bool> query)
    {
        var result = _sqliteConnection.Table<T>()
            .FirstOrDefault(query);

        return result is not null ?
            Result.Succeed(result)
            : Result<T>.Fail("Not found");
    }

    public CollectionResult<TOutput> Select<TOutput>(Func<T, TOutput> query)
    {
        var result = _sqliteConnection.Table<T>()
            .Select(query)
            .ToList();

        return CollectionResult<TOutput>.Succeed(result);
    }

    public CollectionResult<T> OrderBy<TProperty>(Func<T, TProperty> query)
    {
        var result = _sqliteConnection.Table<T>()
            .OrderBy(query)
            .ToList();

        return CollectionResult<T>.Succeed(result);
    }

    public void Dispose()
    {
        _sqliteConnection.Close();
        _sqliteConnection.Dispose();
    }
}