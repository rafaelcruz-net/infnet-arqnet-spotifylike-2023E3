using Microsoft.AspNetCore.Mvc;
using Spotify.Application.Admin;

namespace SpotifyLike.Admin.Controllers
{
    public class UserController : Controller
    {
        private UsuarioAdminService usuarioAdminService;

        public UserController(UsuarioAdminService usuarioAdminService)
        {
            this.usuarioAdminService = usuarioAdminService;
        }

        public IActionResult Index()
        {
            var result = this.usuarioAdminService.ObterTodos();
            return View(result);
        }
    }
}
