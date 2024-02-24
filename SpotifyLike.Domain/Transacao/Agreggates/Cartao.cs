using SpotifyLike.Domain.Core.ValueObject;
using SpotifyLike.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Domain.Transacao.Agreggates
{
    public class Cartao
    {
        private const int INTERVALO_TRANSACAO = -2;
        private const int REPETICAO_TRANSACAO_MERCHANT = 1;

        public Guid Id { get; set; }
        public Boolean Ativo { get; set; }
        public Monetario Limite { get; set; }
        public String Numero { get; set; }
        public virtual IList<Transacao> Transacoes { get; set; } = new List<Transacao>();

        public void CriarTransacao(Merchant merchant, Monetario valor, string Descricao = "")
        {
            //Verificar se o cartão está ativo
            this.IsCartaoAtivo();

            Transacao transacao = new Transacao();
            transacao.Merchant = merchant;
            transacao.Valor = valor;
            transacao.Descricao = Descricao;
            transacao.DtTransacao = DateTime.Now;

            //Verifica limite disponivel
            this.VerificaLimite(transacao);
            
            //Verifica regras antifraude
            this.ValidarTransacao(transacao);

            //Cria numero de autorização
            transacao.Id = Guid.NewGuid();

            //Diminui o limite com o valor da transacao
            this.Limite = this.Limite - transacao.Valor;

            this.Transacoes.Add(transacao);
                
        }

        private void ValidarTransacao(Transacao transacao)
        {
            var ultimasTransacoes = this.Transacoes.Where(x => 
                                                          x.DtTransacao >= DateTime.Now.AddMinutes(INTERVALO_TRANSACAO));
            if (ultimasTransacoes?.Count() >= 3)
                throw new Exception("Cartão utilizado muitas vezes em um período curto");

            var transacaoRepetidaPorMerchant = ultimasTransacoes?
                                                .Where(x => x.Merchant.Nome.ToUpper() == transacao.Merchant.Nome.ToUpper()
                                                       && x.Valor == transacao.Valor)
                                                .Count() == REPETICAO_TRANSACAO_MERCHANT;

            if (transacaoRepetidaPorMerchant)
                throw new Exception("Transacao Duplicada para o mesmo cartão e o mesmo Comerciante");

        }

        private void VerificaLimite(Transacao transacao)
        {
            if (this.Limite < transacao.Valor)
                throw new Exception("Cartão não possui limite para esta transacao");
        }

        private void IsCartaoAtivo()
        {
            if (this.Ativo == false)
                throw new Exception("Cartão não está ativo");
        }
    }
}
