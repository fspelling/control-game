using ControlGame.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorRequest: IRequest
    {
        public string Senha { get; set; }

        public string Email { get; set; }
    }
}
