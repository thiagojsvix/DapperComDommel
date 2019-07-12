
using System.Collections.Generic;
using System.Threading.Tasks;
using Queries.Dominio.Entidades;

namespace Queries.Dominio.Repositorio
{
    public interface IPessoaRepositorio
    {
        Task InitAsync();
        Task DeleteAsync();
        Task<IEnumerable<Pessoa>> ObterPessoaPorProfissaoAsync(string profissao);
    }
}
