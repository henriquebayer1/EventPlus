using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        [HttpPost]
        
        public IActionResult Post(TiposUsuario tiposUsuario)
        {

            try
            {

                _tiposUsuarioRepository.Cadastrar(tiposUsuario);

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

                _tiposUsuarioRepository.Deletar(id);

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

              TiposUsuario tiposUsuarioBuscado =  _tiposUsuarioRepository.BuscarPorId(id);

                return Ok(tiposUsuarioBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpPut]
        public IActionResult AtualizarTitulo(Guid id, TiposUsuario novoTipoUsuario)
        {
            try
            {

                _tiposUsuarioRepository.Atualizar(id, novoTipoUsuario);

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
                return Ok(_tiposUsuarioRepository.Listar());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        
        }



    }
}