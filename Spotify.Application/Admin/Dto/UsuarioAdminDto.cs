using SpotifyLike.Domain.Admin.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Admin.Dto
{
    public class UsuarioAdminDto
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public int Perfil { get; set; }
    }
}
