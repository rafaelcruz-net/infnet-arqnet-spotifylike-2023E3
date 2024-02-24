using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Spotify.Application.Conta.Dto
{
    public class UsuarioDto
    {
        
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public DateTime DtNascimento { get; set; }

        public Guid PlanoId { get; set; }


        [Required]        
        public CartaoDto Cartao { get; set; }

    }


}
