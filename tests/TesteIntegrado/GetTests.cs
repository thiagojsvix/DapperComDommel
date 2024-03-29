﻿using System.Threading.Tasks;
using Dommel;
using TesteIntegrado.Database;
using TesteIntegrado.Infraestrutura;
using TesteIntegrado.Models;
using Xunit;

namespace TesteIntegrado
{
    [Collection("Database")]
    public class GetTests
    {
        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public void Get(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var product = con.Get<Product>(1);
                Assert.NotNull(product);
                Assert.NotEmpty(product.Name);
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public async Task GetAsync(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var product = await con.GetAsync<Product>(1);
                Assert.NotNull(product);
                Assert.NotEmpty(product.Name);
            }
        }
    }
}