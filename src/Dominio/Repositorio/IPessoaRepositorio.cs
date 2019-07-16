using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Repositorio
{
    public interface IPessoaRepositorio
    {
        Task InitAsync();
        Task DeleteAsync();
        Task<IEnumerable<Pessoa>> ObterPessoaPorProfissaoAsync(string profissao);
    }
}
