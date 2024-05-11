using Microsoft.AspNetCore.Mvc;

namespace SpotifyLike.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
