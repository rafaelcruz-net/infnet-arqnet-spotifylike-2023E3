using SpotifyLike.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Repository.Repository
{
    public class PlanoRepository : RepositoryBase<Plano>
    {
        public SpotifyLikeContext Context { get; set; }

        public PlanoRepository(SpotifyLikeContext context) : base(context)
        {
            Context = context;
        }

       
    }
}
