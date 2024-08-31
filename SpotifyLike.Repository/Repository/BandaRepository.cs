using Microsoft.Extensions.Configuration;
using SpotifyLike.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Repository.Repository
{
    public class BandaRepository : CosmosDBContext
    {
        public BandaRepository(IConfiguration configuration): base(configuration)
        {
            this.SetContainer("banda");
        }
    }
}
