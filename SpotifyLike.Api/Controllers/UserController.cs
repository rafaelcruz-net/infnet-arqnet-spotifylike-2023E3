using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spotify.Application.Conta.Dto;
using SpotifyLike.Domain.Conta.Agreggates;

namespace SpotifyLike.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public IActionResult Criar(UsuarioDto dto)
        {
            if (ModelState is { IsValid: false})
                return BadRequest();

            return Ok();

        }

    }
}
