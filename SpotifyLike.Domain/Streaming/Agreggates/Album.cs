using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Domain.Streaming.Aggregates
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public virtual IList<Musica> Musica { get; set; } = new List<Musica>();
        

        public void AdicionarMusica(Musica musica) => 
            this.Musica.Add(musica);
     
        //public void AdicionarMusica(List<Musica> musica) =>
        //    this.Musica.AddRange(musica);


    
    }
}
