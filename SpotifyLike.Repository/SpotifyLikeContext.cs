using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotifyLike.Domain.Admin.Aggregates;
using SpotifyLike.Domain.Conta.Agreggates;
using SpotifyLike.Domain.Notificacao;
using SpotifyLike.Domain.Streaming.Aggregates;
using SpotifyLike.Domain.Transacao.Agreggates;
using SpotifyLike.Repository.Mapping.Conta;
using SpotifyLike.Repository.Mapping.Notificacao;
using SpotifyLike.Repository.Mapping.Streaming;
using SpotifyLike.Repository.Mapping.Transacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Repository
{
    public class SpotifyLikeContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<Assinatura> Assinaturas { get; set; }
        
        public DbSet<Notificacao> Notificacoes { get; set; }
        
        public DbSet<Cartao> Cartoes { get; set; }
        
        public DbSet<Transacao> Transacao { get; set; }
        
        public DbSet<Plano> Planos { get; set; }

        public SpotifyLikeContext(DbContextOptions<SpotifyLikeContext> options) : base(options)
        {

        }


        //Escrever protected internal e vai aparecer OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new PlanoMapping());
            modelBuilder.ApplyConfiguration(new CartaoMapping());
            modelBuilder.ApplyConfiguration(new TransacaoMapping());
            modelBuilder.ApplyConfiguration(new NotificacaoMapping());
            modelBuilder.ApplyConfiguration(new AssinaturaMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}

