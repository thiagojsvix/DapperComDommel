using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Queries.Dominio.Repositorio;

namespace Queries.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio pessoaRepositorio;
        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            this.pessoaRepositorio = pessoaRepositorio;

            this.pessoaRepositorio.InitAsync().Wait();
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            var result = await this.pessoaRepositorio.ObterPessoaPorProfissaoAsync("Mobile Developer");
            return this.Ok(result);
        }
    }
}
