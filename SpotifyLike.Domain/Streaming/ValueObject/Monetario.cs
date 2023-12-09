using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLike.Domain.Streaming.ValueObject
{
    public record Monetario
    {
        public Decimal Valor { get; set; }

        public static implicit operator Decimal(Monetario d) => d.Valor;
        public static implicit operator Monetario(Decimal valor) => new Monetario(valor);

        public Monetario(int valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor monetário não pode ser negativo");

            this.Valor = valor;
        }

        public String Formatado()
        {
            return $"R$ {this.Valor.ToString("N2")}";
        }


    }
}
