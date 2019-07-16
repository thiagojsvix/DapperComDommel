using System.Threading.Tasks;
using Dommel;
using TesteIntegrado.Database;
using TesteIntegrado.Infraestrutura;
using TesteIntegrado.Models;
using Xunit;

namespace TesteIntegrado
{
    [Collection("Database")]
    public class UpdateTests
    {
        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public void Update(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var product = con.Get<Product>(1);
                Assert.NotNull(product);

                product.Name = "Test";
                con.Update(product);

                var newProduct = con.Get<Product>(1);
                Assert.Equal("Test", newProduct.Name);
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public async Task UpdateAsync(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var product = await con.GetAsync<Product>(1);
                Assert.NotNull(product);

                product.Name = "Test";
                con.Update(product);

                var newProduct = await con.GetAsync<Product>(1);
                Assert.Equal("Test", newProduct.Name);
            }
        }
    }
}
