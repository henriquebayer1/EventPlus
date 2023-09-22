using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _InstituicaoRepository;

        public InstituicaoController()
        {
            _InstituicaoRepository = new InstituicaoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Instituicao instituicao)
        {
            try
            {
                _InstituicaoRepository.Cadastrar(instituicao);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


        [HttpGet]
        public IActionResult ListarTodos()
        {

            try
            {

                return Ok(_InstituicaoRepository.Listar());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEvento(Guid id, Instituicao novaInstituicao)
        {
            try
            {

                _InstituicaoRepository.Atualizar(id, novaInstituicao);

                return Ok();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

           

        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id) 
        {
            try
            {
                return Ok(_InstituicaoRepository.BuscarPorId(id));

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {

            try
            {

                _InstituicaoRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
