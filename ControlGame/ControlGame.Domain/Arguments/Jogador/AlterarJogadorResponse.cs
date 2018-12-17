using ControlGame.Domain.Resources;
using System;

namespace ControlGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorResponse
    {
        public Guid Id { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Email { get; set; }

        public string Mensagem { get; set; }

        public static explicit operator AlterarJogadorResponse(Entities.Jogador jogador)
        {
            return new AlterarJogadorResponse()
            {
                Id = jogador.Id,
                Email = jogador.Email.Endereco,
                PrimeiroNome = jogador.Nome.PrimeiroNome,
                UltimoNome = jogador.Nome.UltimoNome,
                Mensagem = string.Format(Message.X_DADOS_ATUALIZADOS, "jogador")
            };
        }
    }
}
