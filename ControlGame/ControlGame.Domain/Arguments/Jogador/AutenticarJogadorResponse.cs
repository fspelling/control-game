using ControlGame.Domain.Interfaces.Arguments;
using System;

namespace ControlGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse: IResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        public static explicit operator AutenticarJogadorResponse(Entities.Jogador jogador)
        {
            return new AutenticarJogadorResponse()
            {
                Id = jogador.Id,
                Email = jogador.Email.Endereco,
                Nome = jogador.Nome.PrimeiroNome,
                Status = (int)jogador.Status
            };
        }
    }
}
