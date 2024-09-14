using AutoMapper;
using Spotify.Application.Conta.Dto;
using SpotifyLike.Domain.Conta.Agreggates;
using SpotifyLike.Domain.Core.Extension;
using SpotifyLike.Domain.Streaming.Aggregates;
using SpotifyLike.Domain.Transacao.Agreggates;
using SpotifyLike.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Conta
{
    public class UsuarioService
    {
        private IMapper Mapper { get; set; }
        private UsuarioRepository UsuarioRepository { get; set; }
        private PlanoRepository PlanoRepository { get; set; }

        private AzureServiceBusService ServiceBusService { get; set; }



        public UsuarioService(IMapper mapper, UsuarioRepository usuarioRepository, PlanoRepository planoRepository, AzureServiceBusService serviceBusService)
        {
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
            PlanoRepository = planoRepository;
            ServiceBusService = serviceBusService;
        }

        public async Task<UsuarioDto> Criar(UsuarioDto dto)
        {
            if (this.UsuarioRepository.Exists(x => x.Email == dto.Email)) 
                throw new Exception("Usuario já existente na base");
            
            
            Plano plano = this.PlanoRepository.GetById(dto.PlanoId);

            if (plano == null)
                throw new Exception("Plano não existente ou não encontrado");

            Cartao cartao = this.Mapper.Map<Cartao>(dto.Cartao);

            Usuario usuario = new Usuario();
            usuario.CriarConta(dto.Nome, dto.Email, dto.Senha, dto.DtNascimento, plano, cartao);

            //TODO: GRAVAR MA BASE DE DADOS
            this.UsuarioRepository.Save(usuario);
            var result = this.Mapper.Map<UsuarioDto>(usuario);

            //Notificar o usuário
            Notificacao notificacao = new Notificacao()
            {
                Mensagem = $"Seja bem vindo ao Spotify Like {usuario.Nome}",
                Nome = usuario.Nome,
                IdUsuario = usuario.Id
            };

            await this.ServiceBusService.SendMessage(notificacao);


            return result;

        }

        public UsuarioDto Obter(Guid id)
        {
            var usuario = this.UsuarioRepository.GetById(id);
            var result = this.Mapper.Map<UsuarioDto>(usuario);
            return result;
        }

        public async Task<UsuarioDto> Autenticar(String email, String senha)
        {
            var usuario = this.UsuarioRepository.Find(x => x.Email == email && x.Senha == senha.HashSHA256()).FirstOrDefault();
            var result = this.Mapper.Map<UsuarioDto>(usuario);


            //Notificar o usuário
            Notificacao notificacao = new Notificacao()
            {
                Mensagem = $"Alerta: {usuario.Nome} acabou de fazer login as {DateTime.Now}",
                Nome = usuario.Nome,
                IdUsuario = usuario.Id
            };

            await this.ServiceBusService.SendMessage(notificacao);

            return result;
        }
    }
}

