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

        public BandaDto Criar(BandaDto dto)
        {
            Banda banda = this.Mapper.Map<Banda>(dto);
            this.BandaRepository.Save(banda);

            return this.Mapper.Map<BandaDto>(banda);
        }

        public BandaDto Obter(Guid id)
        {
            var banda = this.BandaRepository.GetById(id);
            return this.Mapper.Map<BandaDto>(banda);
        }

        public IEnumerable<BandaDto> Obter()
        {
            var banda = this.BandaRepository.GetAll();
            return this.Mapper.Map<IEnumerable<BandaDto>>(banda);
        }

        public AlbumDto AssociarAlbum(AlbumDto dto)
        {
            var banda = this.BandaRepository.GetById(dto.BandaId);

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            var novoAlbum = this.AlbumDtoParaAlbum(dto);

            banda.AdicionarAlbum(novoAlbum);

            this.BandaRepository.Update(banda);

            var result = this.AlbumParaAlbumDto(novoAlbum);

            return result;

        }

        public AlbumDto ObterAlbum(Guid idBanda, Guid id)
        {
            var banda = this.BandaRepository.GetById(idBanda);

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            var album = banda.Albums.FirstOrDefault(x => x.Id == id);

            var result = AlbumParaAlbumDto(album);
            result.BandaId = banda.Id;

            return result;

        }

        private Album AlbumDtoParaAlbum(AlbumDto dto)
        {
            Album album = new Album()
            {
                Nome = dto.Nome
            };

            foreach (MusicDto item in dto.Musicas)
            {
                album.AdicionarMusica(new Musica
                {
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
