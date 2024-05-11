using SpotifyLike.Domain.Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Domain.Admin.Aggregates
{
    public class UsuarioAdmin
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public Perfil Perfil { get; set; }

        public void CriptografarSenha()
        {
            this.Password = this.Password.HashSHA256();
        }

    }
}
