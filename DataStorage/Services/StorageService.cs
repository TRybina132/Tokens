using System;
using DataStorage.Models;
using DataStorage.Services.Abstractions;
using ManagedCode.Communication;
using Microsoft.Extensions.Options;
using SQLite;
using Data.Models;

namespace DataStorage.Services;

public abstract class StorageService<T> : IStorageService<T>
        where T : BaseModel, new()
{
    private readonly DatabaseSettings _databaseSettings;
    private readonly SQLiteConnection _sqliteConnection;

    protected Result CheckIfOperationSuccessfull(int result) =>
        result > 0 ? Result.Succeed() : Result.Fail();

    public StorageService(IOptions<DatabaseSettings> databaseOptions)
	{
        try
        {
            _databaseSettings = databaseOptions.Value;
            _sqliteConnection = new SQLiteConnection(_databaseSettings.FilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
	}

    public Result<T> GetItem(string id)
    {
        var result = _sqliteConnection.Table<T>()
            .FirstOrDefault(item => item.Id == id);

        return result is not null ?
            Result.Succeed(result)
            : Result<T>.Fail("Not found");
    }

    public Result Save(T model)
    {
        var result = _sqliteConnection.Insert(model);

        return CheckIfOperationSuccessfull(result);
    }

    public Result UpdateItem(T newValue)
    {
        var result = _sqliteConnection.Update(newValue);

        return CheckIfOperationSuccessfull(result);
    }

    public Result Delete(string id)
    {
        var result = _sqliteConnection.Delete<T>(id);

        return CheckIfOperationSuccessfull(result);
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