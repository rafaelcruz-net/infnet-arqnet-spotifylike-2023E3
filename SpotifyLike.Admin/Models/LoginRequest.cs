using System.ComponentModel.DataAnnotations;

namespace SpotifyLike.Admin.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Campo Email não está em um formato correto")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Campo Password é obrigatório")]
        public String Password { get; set; }
    }
}
