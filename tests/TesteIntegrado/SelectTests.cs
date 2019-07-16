
using System;
using System.Linq;
using System.Threading.Tasks;
using Dommel;
using FluentAssertions;
using TesteIntegrado.Database;
using TesteIntegrado.Infraestrutura;
using TesteIntegrado.Models;
using Xunit;

namespace TesteIntegrado
{
    [Collection("Database")]
    public class SelectTests
    {
        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public async Task SelectAsyncEqual(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var products = await con.SelectAsync<Product>(p => p.CategoryId == 1);
                Assert.Equal(10, products.Count());
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public async Task SelectAsyncContains(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var products = await con.SelectAsync<Product>(p => p.Name.Contains("Anton"));
                Assert.Equal(4, products.Count());
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public void SelectAsyncContainsVariable(DatabaseDriver database)
        {
            var productName = "Anton";
            using (var con = database.GetConnection())
            {
                Action action = () => con.SelectAsync<Product>(p => p.Name.Contains(productName));
                action.Should().Throw<InvalidCastException>();
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public void SelectAsyncStartsWith(DatabaseDriver database)
        {
            var productName = "Cha";
            using (var con = database.GetConnection())
            {
                Action action = () => con.SelectAsync<Product>(p => p.Name.StartsWith(productName));
                action.Should().Throw<InvalidCastException>();
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public void SelectAsyncEndsWith(DatabaseDriver database)
        {
            var productName = "2";
            using (var con = database.GetConnection())
            {
                Action action = () => con.SelectAsync<Product>(p => p.Name.EndsWith(productName));
                action.Should().Throw<InvalidCastException>();
            }
        }
    }
}
