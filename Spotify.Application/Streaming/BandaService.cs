using AutoMapper;
using Spotify.Application.Streaming.Dto;
using SpotifyLike.Domain.Streaming.Aggregates;
using SpotifyLike.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Streaming
{
    public class BandaService
    {
        private BandaRepository BandaRepository { get; set; }
        private IMapper Mapper { get; set; }


        public BandaService(BandaRepository bandaRepository, IMapper mapper)
        {
            BandaRepository = bandaRepository;
            Mapper = mapper;
        }

        public async Task<BandaDto> Criar(BandaDto dto)
        {
            Banda banda = this.Mapper.Map<Banda>(dto);
            await this.BandaRepository.SaveOrUpate(banda, banda.BandaKey);

            return this.Mapper.Map<BandaDto>(banda);
        }

        public async Task<BandaDto> Obter(Guid id)
        {
            var banda =  await this.BandaRepository.ReadItem<Banda>(id.ToString());
            return this.Mapper.Map<BandaDto>(banda);
        }

        public async Task<IEnumerable<BandaDto>> Obter()
        {
            var banda = await this.BandaRepository.ReadAllItem<Banda>();
            return this.Mapper.Map<IEnumerable<BandaDto>>(banda);
        }

        public async Task<AlbumDto> AssociarAlbum(AlbumDto dto)
        {
            var banda = await this.BandaRepository.ReadItem<Banda>(dto.BandaId.ToString());

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            var novoAlbum = this.AlbumDtoParaAlbum(dto);

            banda.AdicionarAlbum(novoAlbum);

            await this.BandaRepository.SaveOrUpate<Banda>(banda, banda.BandaKey);

            var result = this.AlbumParaAlbumDto(novoAlbum);

            return result;

        }

        public async Task<AlbumDto> ObterAlbumPorId(Guid idBanda, Guid id)
        {
            var banda = await this.BandaRepository.ReadItem<Banda>(idBanda.ToString());

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            var album = (from x in banda.Albums
                         select x
                         ).FirstOrDefault(x => x.Id == id);

            var result = AlbumParaAlbumDto(album);
            result.BandaId = banda.Id;

            return result;

        }

        public async Task<List<AlbumDto>> ObterAlbum(Guid idBanda)
        {
            var banda = await this.BandaRepository.ReadItem<Banda>(idBanda.ToString());

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            var result = new List<AlbumDto>();

            foreach (var item in banda.Albums)
            {
                result.Add(AlbumParaAlbumDto(item));
            }

            return result;

        }

        private Album AlbumDtoParaAlbum(AlbumDto dto)
        {
            Album album = new Album()
            {
                Id = dto.Id,
                Nome = dto.Nome
            };

            foreach (MusicDto item in dto.Musicas)
            {
                album.AdicionarMusica(new Musica
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Duracao = new SpotifyLike.Domain.Streaming.ValueObject.Duracao(item.Duracao)
                });
            }

            return album;
        }

        private AlbumDto AlbumParaAlbumDto(Album album)
        {
            AlbumDto dto = new AlbumDto(); 
            dto.Id = album.Id;
            dto.Nome = album.Nome;

            foreach (var item in album.Musica)
            {
                var musicaDto = new MusicDto()
                {
                    Id = item.Id,
                    Duracao = item.Duracao.Valor,
                    Nome = item.Nome
                };

                dto.Musicas.Add(musicaDto);
            }

            return dto;
        }



    }
}
