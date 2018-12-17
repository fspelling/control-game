using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlGame.Domain.Entities;

namespace ControlGame.Domain.Arguments.Jogador
{
    public class JogadorResponse
    {
        public Guid Id { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }

        public static explicit operator JogadorResponse(Entities.Jogador jogador)
        {
            return new JogadorResponse()
            {
                Id = jogador.Id,
                PrimeiroNome = jogador.Nome.PrimeiroNome,
                UltimoNome = jogador.Nome.UltimoNome,
                NomeCompleto = jogador.ToString(),
                Email  = jogador.Email.Endereco,
                Status = jogador.Status.ToString()
            };
        }
    }
}
