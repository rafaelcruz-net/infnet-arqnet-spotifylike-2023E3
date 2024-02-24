using SpotifyLike.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Repository.Repository
{
    public class BandaRepository : RepositoryBase<Banda>
    {
        public BandaRepository(SpotifyLikeContext context) : base(context)
        {
        }
    }
}
