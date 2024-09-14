using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpotifyLike.Domain.Streaming.Aggregates
{
    public class Banda
    {
        
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("nome")]
        public String Nome { get; set; }
        
        [JsonProperty("descricao")]
        public String Descricao { get; set; }

        [JsonProperty("backdrop")]
        public String Backdrop { get; set; }

        [JsonProperty("bandaKey")]
        public string BandaKey = "banda-partition";

        
        [JsonProperty("albuns")]
        public virtual IList<Album> Albums { get; set; } = new List<Album>();

        public void AdicionarAlbum(Album album) =>
            this.Albums.Add(album);


    }
}
