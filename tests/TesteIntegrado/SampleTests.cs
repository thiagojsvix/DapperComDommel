using System.Threading.Tasks;
using Dommel;
using TesteIntegrado.Database;
using TesteIntegrado.Infraestrutura;
using TesteIntegrado.Models;
using Xunit;

namespace TesteIntegrado
{

    [Collection("Database")]
    public class SampleTests
    {
        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public void Sample(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                _ = con.GetAll<Product>();
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public async Task SampleAsync(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                _ = await con.GetAllAsync<Product>();
            }
        }
    }
}
