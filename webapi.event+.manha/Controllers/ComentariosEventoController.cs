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
    public class ComentariosEventoController : ControllerBase
    {

        private readonly IComentariosEventoRepository _ComentariosEventoRepository;
        public ComentariosEventoController()
        {
            _ComentariosEventoRepository = new ComentariosEventoRepository();

        }

        [HttpGet("Listar Todos")]
        public IActionResult ListarTodos()
        {

            try
            {
                return Ok(_ComentariosEventoRepository.Listar());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


        [HttpPost]
        public IActionResult Cadastar(ComentariosEvento comentario)
        {

            try
            {
                _ComentariosEventoRepository.Cadastrar(comentario);

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

                _ComentariosEventoRepository.Deletar(id);

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


                return Ok(_ComentariosEventoRepository.BuscarPorId(id));


            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }


    }
}
