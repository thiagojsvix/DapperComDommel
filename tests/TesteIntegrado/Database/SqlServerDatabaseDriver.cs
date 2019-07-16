﻿using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace TesteIntegrado.Database
{
    public class SqlServerDatabaseDriver : DatabaseDriver
    {
        public override string TempDbDatabaseName => "tempdb";
        protected override DbConnection GetConnection(string databaseName)
        {
            var connectionString = $"Server=tcp:127.0.0.1,1433;Database={databaseName};User Id=sa;Password=Password12!;";
            return new SqlConnection(connectionString);
        }

        protected override async Task CreateDatabase()
        {
            using (var con = GetConnection(TempDbDatabaseName))
            {
                await con.ExecuteAsync($"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'{DefaultDatabaseName}') BEGIN CREATE DATABASE {DefaultDatabaseName}; END;");
            }
        }

        protected override async Task<bool> CreateTables()
        {
            using (var con = GetConnection(DefaultDatabaseName))
            {
                var sql = @"IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
                            BEGIN
                                CREATE TABLE dbo.Categories (Id int IDENTITY(1,1) PRIMARY KEY, Name VARCHAR(255));
                                CREATE TABLE dbo.Products (Id int IDENTITY(1,1) PRIMARY KEY, CategoryId int, Name VARCHAR(255));
                                CREATE TABLE dbo.Orders (Id int IDENTITY(1,1) PRIMARY KEY, Created DATETIME NOT NULL);
                                CREATE TABLE dbo.OrderLines (Id int IDENTITY(1,1) PRIMARY KEY, OrderId int, Line VARCHAR(255));
                                CREATE TABLE dbo.Foos (Id int IDENTITY(1,1) PRIMARY KEY, Name VARCHAR(255));
                                CREATE TABLE dbo.Bars (Id int IDENTITY(1,1) PRIMARY KEY, Name VARCHAR(255));
                                SELECT 1;
                            END";

                var created = await con.ExecuteScalarAsync(sql);

                // A result means the tables were just created
                return created != null;
            }
        }
    }
}
