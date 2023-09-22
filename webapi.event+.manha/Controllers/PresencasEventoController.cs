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
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _PresencasEventoRepository;


        public PresencasEventoController()
        {
            _PresencasEventoRepository = new PresencasEventoRepository();
        }


        [HttpGet("Listar Todos")]
        public IActionResult ListarTodos()
        {

            try
            {
                return Ok(_PresencasEventoRepository.ListarTodos());
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
                return Ok(_PresencasEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        }

        [HttpPost]
        public IActionResult Cadastrar(PresencasEvento presencaEvento)
        {

            try
            {

                _PresencasEventoRepository.Cadastrar(presencaEvento);

                return Ok();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpPut]
        public IActionResult Atualizar(Guid id, PresencasEvento presencaEventoAtualizada)
        {

            try
            {

                _PresencasEventoRepository.Atualizar(id, presencaEventoAtualizada);

                return Ok();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        }




    }
}
