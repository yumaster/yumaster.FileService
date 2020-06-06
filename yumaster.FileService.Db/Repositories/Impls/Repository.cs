﻿using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using yumaster.FileService.Db.Options;

namespace yumaster.FileService.Db.Repositories.Impls
{
    internal class Repository : IRepository
    {
        protected async Task<long> InsertAsync(IDbConnection conn, DatabaseType dbType, string sql, object param, Action<int> setIdCb = null)
        {
            if (dbType == DatabaseType.MySql)
                sql += "; SELECT @@IDENTITY AS Id";
            else if (dbType == DatabaseType.SqlServer)
                sql += "; select SCOPE_IDENTITY() Id";
            var id = await conn.ExecuteScalarAsync<int>(sql, param);
            setIdCb?.Invoke(id);
            return id;
        }
    }
}
