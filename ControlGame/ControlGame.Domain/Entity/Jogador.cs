using ControlGame.Domain.Enum;
using ControlGame.Domain.ValueObjects;
using System;

namespace ControlGame.Domain.Entities
{
    public class Jogador
    {
        public Guid Id { get; set; }

        public Nome Nome { get; set; }

        public Email Email { get; set; }

        public string Senha { get; private set; }

        public EnumSituacaoJogador Status { get; set; }


    }
}
