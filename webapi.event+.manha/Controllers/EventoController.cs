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
    public class EventoController : ControllerBase
    {

        private IEventoRepository _EventoRepository;

        public EventoController()
        {
            _EventoRepository = new EventoRepository();
        }


        [HttpGet("Listar Todos")]
        public IActionResult ListarTodos()
        {

            try
            {
                return Ok(_EventoRepository.Listar());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


        [HttpPost]
        public IActionResult Cadastar(Evento evento)
        {

            try
            {
                _EventoRepository.Cadastrar(evento);

                return Ok();

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

                _EventoRepository.Deletar(id);

                return StatusCode(201);
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


                return Ok(_EventoRepository.BuscarPorId(id));


            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarEvento(Guid id, Evento novoEvento)
        {
            try
            {

                _EventoRepository.Atualizar(id, novoEvento);

                return Ok();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }




        }

    }
}
