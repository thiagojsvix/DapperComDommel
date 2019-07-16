
using System;
using System.Collections.Generic;
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
    public class InsertTests
    {
        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public void Insert(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var id = Convert.ToInt32(con.Insert(new Product { Name = "blah" }));
                var product = con.Get<Product>(id);

                product.Should().NotBeNull();
                product.Name.Should().Be("blah");
                product.Id.Should().Be(id);
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public async Task InsertAsync(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var id = Convert.ToInt32(await con.InsertAsync(new Product { Name = "blah" }));
                var product = await con.GetAsync<Product>(id);

                product.Should().NotBeNull();
                product.Name.Should().Be("blah");
                product.Id.Should().Be(id);
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public void InsertAll(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var ps = new List<Foo>
                {
                    new Foo { Name = "blah" },
                    new Foo { Name = "blah" },
                    new Foo { Name = "blah" },
                };

                con.InsertAll(ps);

                var blahs = con.Select<Foo>(p => p.Name == "blah");
                blahs.Count().Should().Be(3);
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public async Task InsertAllAsync(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var ps = new List<Bar>
                {
                    new Bar { Name = "blah" },
                    new Bar { Name = "blah" },
                    new Bar { Name = "blah" },
                };

                await con.InsertAllAsync(ps);

                var blahs = await con.SelectAsync<Bar>(p => p.Name == "blah");
                blahs.Count().Should().Be(3);
            }
        }
    }
}
