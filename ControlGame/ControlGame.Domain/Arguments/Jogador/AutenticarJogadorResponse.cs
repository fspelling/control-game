using ControlGame.Domain.Interfaces.Arguments;
using ControlGame.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse: IResponse
    {
        public string Nome { get; set; }

        public Email Email { get; set; }
    }
}
