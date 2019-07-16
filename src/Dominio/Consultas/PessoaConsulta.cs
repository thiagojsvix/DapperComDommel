using System;
using System.Linq.Expressions;
using Dominio.Entidades;

namespace Dominio.Consultas
{
    public static class PessoaConsulta
    {
        public static  Expression<Func<Pessoa, bool>> ObterPessoaPorProfissao(string profissao)
        {
            return x => x.JobTitle == profissao;
        }
    }
}
