using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.Application.Conta;
using Spotify.Application.Conta.Dto;
using SpotifyLike.Domain.Conta.Agreggates;

namespace SpotifyLike.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UserController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Criar(UsuarioDto dto)
        {
            if (ModelState is { IsValid: false})
                return BadRequest();
           
            var result = this._usuarioService.Criar(dto);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult Obter(Guid id)
        {
            var result = this._usuarioService.Obter(id);

            if (result == null)
                return NotFound();

            return Ok(result);

        }

    }
}
