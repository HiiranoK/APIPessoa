using APIPessoa.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIPessoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class PessoaController : ControllerBase
    {
        public List<Pessoa> pessoas = new List<Pessoa>();
        public PessoaController()
        {
            pessoas.Add(new Pessoa
            {
                Nome = "Amanda",
                DataNascimento = new DateTime(1994, 05, 09)
            });
            pessoas.Add(new Pessoa
            {
                Nome = "Joaquim",
                DataNascimento = new DateTime(1968, 09, 17)
            });

        }

        //ActionResult informa conteudo do body da resposta (response),
        //              utilizamos quando sabemos o conteudo de retorno;
        //IActionResult n�o informa conteudo do body da resposta (response),
        //              utilizamos quando n�o sabemos o conteudo exato
        //Ambos s�o informados com StatusCode;
        [HttpGet("todos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Pessoa>> Consultar()
        {
            PessoaRepository repository = new();

            List<Pessoa> pessoasBanco = repository.SelecionarPessoas();

            return Ok(pessoasBanco);
        }

        [HttpGet]
        public ActionResult<Pessoa> ConsultarPessoa(string nome)
        {
            Pessoa pessoa = pessoas.FirstOrDefault(p => p.Nome == nome);
            return Ok(pessoa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Pessoa> Inserir(Pessoa pessoa)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            pessoas.Add(pessoa);
            return CreatedAtAction(nameof(ConsultarPessoa), pessoa);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Pessoa>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Alterar(int index, Pessoa pessoa)
        {
            var content = Request.Headers.ContentType;
            if (index < 0 || index > 1)
            {
                return BadRequest();
            }

            pessoas[index] = pessoa;
            return Ok(content);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Deletar(string nome)
        {
            Pessoa pessoaDeletar = pessoas.FirstOrDefault(p => p.Nome == nome);
            if (pessoaDeletar == null)
            {
                return BadRequest();
            }

            pessoas.Remove(pessoaDeletar);
            return NoContent();
        }
    }
}