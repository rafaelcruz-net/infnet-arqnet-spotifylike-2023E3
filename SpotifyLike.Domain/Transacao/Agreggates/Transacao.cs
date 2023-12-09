using SpotifyLike.Domain.Core.ValueObject;
using SpotifyLike.Domain.Streaming.ValueObject;
using SpotifyLike.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Domain.Transacao.Agreggates
{
    public class Transacao
    {


        public Guid Id { get; set; }
        public DateTime DtTransacao { get; set; }
        public Monetario Valor { get; set; }
        public String Descricao { get; set; }
        public Merchant Merchant { get; set; }
        
    }
}
