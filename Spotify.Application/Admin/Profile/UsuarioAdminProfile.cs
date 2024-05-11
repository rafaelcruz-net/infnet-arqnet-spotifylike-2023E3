using Spotify.Application.Admin.Dto;
using Spotify.Application.Conta.Dto;
using SpotifyLike.Domain.Admin.Aggregates;
using SpotifyLike.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Admin.Profile
{
    public class UsuarioAdminProfile :AutoMapper.Profile
    {
        public UsuarioAdminProfile()
        {
            CreateMap<UsuarioAdminDto, UsuarioAdmin>()
                .ForMember(x => x.Perfil, m => m.MapFrom(f => (Perfil)f.Perfil))
                .ReverseMap();

        }

    }
}
