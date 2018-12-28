using ControlGame.Domain.Resources;
using System;

namespace ControlGame.Domain.Arguments.Jogo
{
    public class AdicionarJogoResponse
    {
        public Guid Id { get; set; }

        public string Mensagem { get; set; }

        public static explicit operator AdicionarJogoResponse(Entities.Jogo jogo)
        {
            return new AdicionarJogoResponse()
            {
                Id = jogo.Id,
                Mensagem = Message.X_OPERACAO_REALIZADA_SUCESSO
            };
        }
    }
}
