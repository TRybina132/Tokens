using System;
using Data.Models;
using DataStorage.Models;
using DataStorage.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace DataStorage.Services
{
    public class TokenStorageService : StorageService<Token>, ITokenStorageService
    {
        public TokenStorageService(IOptions<DatabaseSettings> databaseOptions)
            : base(databaseOptions)
        {
        }
    }
}

