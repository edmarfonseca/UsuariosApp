using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.Domain.Dtos;
using UsuariosApp.Domain.Interfaces.Services;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("criar")]
        [ProducesResponseType(typeof(CriarUsuarioResponse), 201)]
        public IActionResult Criar([FromBody] CriarUsuarioRequest dto)
        {
            try
            {
                return StatusCode(201, _usuarioService.CriarUsuario(dto));
            }
            catch(ValidationException e)
            {
                return StatusCode(400, new { errors = e.Errors.Select(e => e.ErrorMessage) });
            }
            catch(ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(AutenticarUsuarioResponse), 200)]
        public IActionResult Autenticar([FromBody] AutenticarUsuarioRequest dto)
        {
            try
            {
                return StatusCode(200, _usuarioService.AutenticarUsuario(dto));
            }
            catch(ApplicationException e)
            {
                return StatusCode(401, new { e.Message });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
