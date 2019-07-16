using TesteIntegrado.Database;
using Xunit;

namespace TesteIntegrado.Infraestrutura
{
    public class DatabaseTestData : TheoryData<DatabaseDriver>
    {
        public DatabaseTestData()
        {
            // Define os provedores de banco de dados a serem usados para cada método de teste
            // Esses provedores são usados para inicializar os bancos de dados no
            // DatabaseFixture.
            base.Add(new SqlServerDatabaseDriver());
        }
    }
}
