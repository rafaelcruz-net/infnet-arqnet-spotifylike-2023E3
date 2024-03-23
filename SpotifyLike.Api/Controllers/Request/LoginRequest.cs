using System.ComponentModel.DataAnnotations;

namespace SpotifyLike.Api.Controllers.Request
{
    public class LoginRequest
    {

        [Required(ErrorMessage = "Campo Email é obrigatório")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        public String Senha { get; set; }
    }
}
