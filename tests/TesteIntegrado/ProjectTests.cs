﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Dommel;
using TesteIntegrado.Database;
using TesteIntegrado.Infraestrutura;
using Xunit;

namespace TesteIntegrado
{
    [Collection("Database")]
    public class ProjectTests
    {
        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public void Project(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var p = con.Project<ProductSmall>(1);
                Assert.NotEqual(0, p.Id);
                Assert.NotNull(p.Name);
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public async Task ProjectAsync(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var p = await con.ProjectAsync<ProductSmall>(1);
                Assert.NotEqual(0, p.Id);
                Assert.NotNull(p.Name);
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public void ProjectAll(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var ps = con.ProjectAll<ProductSmall>();
                Assert.NotEmpty(ps);
                Assert.All(ps, p =>
                {
                    Assert.NotEqual(0, p.Id);
                    Assert.NotNull(p.Name);
                });
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public async Task ProjectAllAsync(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var ps = await con.ProjectAllAsync<ProductSmall>();
                Assert.NotEmpty(ps);
                Assert.All(ps, p =>
                {
                    Assert.NotEqual(0, p.Id);
                    Assert.NotNull(p.Name);
                });
            }
        }
        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public void ProjectPagedAll(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var ps = con.ProjectPaged<ProductSmall>(pageNumber: 1, pageSize: 5);
                Assert.NotEmpty(ps);
                Assert.All(ps, p =>
                {
                    Assert.NotEqual(0, p.Id);
                    Assert.NotNull(p.Name);
                });
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseTestData))]
        public async Task ProjectPagedAsync(DatabaseDriver database)
        {
            using (var con = database.GetConnection())
            {
                var ps = await con.ProjectPagedAsync<ProductSmall>(pageNumber: 1, pageSize: 5);
                Assert.NotEmpty(ps);
                Assert.All(ps, p =>
                {
                    Assert.NotEqual(0, p.Id);
                    Assert.NotNull(p.Name);
                });
            }
        }

        // Define a entidade padrão
        [Table("Products")]
        public class ProductSmall
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
