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
    public class TiposEventoController : ControllerBase
    {

        private ITiposEventoRepository _tiposEventoRepository;

        public TiposEventoController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }

        [HttpPost]

        public IActionResult Post(TiposEvento tiposEvento)
        {

            try
            {

                _tiposEventoRepository.Cadastrar(tiposEvento);

                return StatusCode(201);
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

                _tiposEventoRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]

        public IActionResult ListarPorId(Guid id)
        {

            try
            {

                TiposEvento tiposEventoBuscado = _tiposEventoRepository.BuscarPorId(id);

                return Ok(tiposEventoBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPut]
        public IActionResult AtualizarTitulo(Guid id, TiposEvento novoTipoEvento)
        {
            try
            {

                _tiposEventoRepository.Atualizar(id, novoTipoEvento);

                return StatusCode(201);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }




        }

        [HttpGet("Listar Todos")]

        public IActionResult ListarTodos()
        {

            try
            {
                return Ok(_tiposEventoRepository.Listar());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }



    }
}
