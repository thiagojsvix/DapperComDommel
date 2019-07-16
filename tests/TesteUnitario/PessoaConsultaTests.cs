using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dominio.Consultas;
using Dominio.Entidades;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Queries.Tests
{
    public class PessoaConsultaTests
    {
        private readonly IEnumerable<Pessoa> pessoa;

        public PessoaConsultaTests()
        {
            var dataJson = System.IO.File.ReadAllText(this.GetPathFileData());
            pessoa = JsonConvert.DeserializeObject<IList<Pessoa>>(dataJson);
        }

        [Fact]
        public void DeveRetornarQuatroRegistrosQuandoProfissaoForSoftwareEnginner()
        {
            var expression = PessoaConsulta.ObterPessoaPorProfissao("Software Engineer");
            var result = this.pessoa.AsQueryable().Where(expression);
            result.Should().HaveCount(4);
        }

        [Fact]
        public void DeveRetornarVazioQuandoProfissaoForDeveloper()
        {
            var expression = PessoaConsulta.ObterPessoaPorProfissao("Test Developer");
            var result = this.pessoa.AsQueryable().Where(expression);
            result.Should().HaveCount(0);
        }
        
        private string GetPathFileData()
        {
            var binPath = Environment.CurrentDirectory;
            var path =  Path.GetFullPath(Path.Combine(binPath, "..","..","..","..","..", "Data.json"));
            return path;
        }
    }
}
