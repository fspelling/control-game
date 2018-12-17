using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorRequest
    {
        public Guid Id { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Email { get; set; }
    }
}
