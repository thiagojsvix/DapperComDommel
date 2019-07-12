using System;
using System.Linq.Expressions;
using Queries.Dominio.Entidades;

namespace Queries.Dominio.Consultas
{
    public static class PessoaConsulta
    {
        public static  Expression<Func<Pessoa, bool>> ObterPessoaPorProfissao(string profissao)
        {
            return x => x.JobTitle == profissao;
        }
    }
}
