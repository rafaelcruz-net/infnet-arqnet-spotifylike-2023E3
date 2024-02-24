using SpotifyLike.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Repository.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public SpotifyLikeContext Context { get; set; }

        public UsuarioRepository(SpotifyLikeContext context) : base(context)
        {
            Context = context;
        }

    }
}
