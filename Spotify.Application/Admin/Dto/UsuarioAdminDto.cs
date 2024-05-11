using SpotifyLike.Domain.Admin.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Admin.Dto
{
    public class UsuarioAdminDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Campo Email não está em um formato correto")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Campo Password é obrigatório")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Campo Perfil é obrigatório")]
        public int? Perfil { get; set; }
    }
}
