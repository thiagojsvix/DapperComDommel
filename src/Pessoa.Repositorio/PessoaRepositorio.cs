
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using Dommel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Queries.Dominio.Consultas;
using Queries.Dominio.Entidades;
using Queries.Dominio.Repositorio;

namespace Queries.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly string ConnectionString;
        public PessoaRepositorio(IConfiguration configuration)
        {
            this.ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task InitAsync()
        {
            using (DbConnection db = new SqlConnection(this.ConnectionString))
            {
                var dataJson = File.ReadAllText(this.GetPathFileData());
                var pessoa = JsonConvert.DeserializeObject<IList<Pessoa>>(dataJson);

                await this.DeleteAsync();

                foreach (var item in pessoa)
                    await db.InsertAsync(item);
            }
        }

        public async Task DeleteAsync()
        {
            using (DbConnection db = new SqlConnection(this.ConnectionString))
            {
                await db.DeleteAllAsync<Pessoa>();
            }
        }

        public async Task<IEnumerable<Pessoa>> ObterPessoaPorProfissaoAsync(string profissao)
        {
            using (var db = new SqlConnection(this.ConnectionString))
            {
                var result = await Task.FromResult(db.Select<Pessoa>(x => x.JobTitle.Contains(profissao)));
                return result;
            }
        }

        private string GetPathFileData()
        {
            var binPath = Environment.CurrentDirectory;
            var path = Path.GetFullPath(Path.Combine(binPath, "..", "..", "Data.json"));
            return path;
        }
    }
}
