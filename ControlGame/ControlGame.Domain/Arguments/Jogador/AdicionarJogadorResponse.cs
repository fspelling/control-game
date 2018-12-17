using ControlGame.Domain.Entities;
using ControlGame.Domain.Interfaces.Arguments;
using ControlGame.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGame.Domain.Arguments.Jogador
{
    public class AdicionarJogadorResponse: IResponse
    {
        public Guid Id { get; set; }

        public string Mensagem { get; set; }

        public static explicit operator AdicionarJogadorResponse(Entities.Jogador jogador)
        {
            return new AdicionarJogadorResponse()
            {
                Id = jogador.Id,
                Mensagem = Message.X_OPERACAO_REALIZADA_SUCESSO
            };
        }
    }
}
