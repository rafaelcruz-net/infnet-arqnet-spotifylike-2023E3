using SpotifyLike.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Domain.Conta.Agreggates
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Boolean Publica { get; set; }
        public virtual Usuario Usuario { get; set; } 
        public virtual IList<Musica> Musicas { get; set; }
        public DateTime DtCriacao { get; set; }

    }
}

