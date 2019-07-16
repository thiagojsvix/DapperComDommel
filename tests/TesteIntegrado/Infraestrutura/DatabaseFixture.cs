
using System;
using System.Linq;
using System.Threading.Tasks;
using TesteIntegrado.Database;
using Xunit;

namespace TesteIntegrado.Infraestrutura
{
    public class DatabaseFixture : IAsyncLifetime
    {
        private readonly DatabaseDriver[] Databases;

        public DatabaseFixture()
        {
            this.Databases = new DatabaseTestData()
                .Select(x => x[0])
                .OfType<DatabaseDriver>()
                .ToArray();

            if (this.Databases.Length == 0)
                throw new InvalidOperationException($"Nenhum Database definido em {nameof(DatabaseTestData)} theory data.");
        }

        public async Task InitializeAsync()
        {
            foreach (var database in this.Databases)
                await database.InitializeAsync();
        }

        public async Task DisposeAsync()
        {
            foreach (var database in this.Databases)
                await database.DisposeAsync();
        }
    }
}
