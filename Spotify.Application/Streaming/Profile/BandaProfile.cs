using Spotify.Application.Streaming.Dto;
using SpotifyLike.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Streaming.Profile
{
    public class BandaProfile : AutoMapper.Profile
    {
        public BandaProfile()
        {
            CreateMap<BandaDto, Banda>()
                .ReverseMap();
        }
    }
}
