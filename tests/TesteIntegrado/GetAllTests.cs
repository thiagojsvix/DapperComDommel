using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dommel;
using TesteIntegrado.Database;
using TesteIntegrado.Infraestrutura;
using TesteIntegrado.Models;
using Xunit;

namespace TesteIntegrado
{
    [Collection("Database")]
    public class GetAllTests
    {
        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public void GetAll(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var products = con.GetAll<Product>();
                Assert.NotEmpty(products);
                Assert.All(products, p => Assert.NotEmpty(p.Name));
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public async Task GetAllAsync(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var products = await con.GetAllAsync<Product>();
                Assert.NotEmpty(products);
                Assert.All(products, p => Assert.NotEmpty(p.Name));
            }
        }
    }
}
